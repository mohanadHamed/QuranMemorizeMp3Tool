using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace QuranMemorizeMp3Tool
{
   class QuranMp3JoinUtil
   {
      public bool Processing { get; private set; }

      private Reciter reciter;
      private string dstDir;
      private ProgressBar downloadProgressBar;
      private ProgressBar totalProgressBar;
      private bool downloadCompleted;

      private const string stageDir = "stage";

      public QuranMp3JoinUtil(Reciter reciter, string dstDir, ProgressBar downloadProgressBar, ProgressBar totalProgressBar)
      {
         this.reciter = reciter;
         this.dstDir = dstDir;
         this.downloadProgressBar = downloadProgressBar;
         this.totalProgressBar = totalProgressBar;
      }

      public void Done()
      {
         Processing = false;
         downloadProgressBar.Value = 0;
         totalProgressBar.Value = 0;
      }

      public void GenerateJoinedMp3(int juz, DynamicGap dynamicGap, decimal fixedGap)
      {
         Processing = true;

         CleanDirectory(stageDir);
         CleanDirectory(dstDir);

         var navItems = QuranDailyPlanUtil.GetAllNavigationItems(juz);
         var blankAudioOneSecondStream = Assembly.GetEntryAssembly().GetManifestResourceStream("QuranMemorizeMp3Tool.blank_one_sec.mp3");
         
         int currentDay = 1;
         foreach (var navItem in navItems)
         {
            if (Processing == false) break;

            var outFileName = Path.Combine(dstDir, string.Format("day_{0}_{1}.mp3", currentDay++, navItem.Title));
            using (var fs = File.OpenWrite(outFileName))
            {
               if (Processing == false) break;

               var ayaInfos = GetRangeAyaList(navItem.rangeOfAyas);
               foreach (var ayaInfo in ayaInfos)
               {
                  var isLastAya = ayaInfo.EqualsAya(ayaInfos[ayaInfos.Count - 1]);
                  var nextAyaInfo = isLastAya ? ayaInfo : AyaUtil.GetNextAyaInfoFromCurrent(ayaInfo);

                  DownloadAyaIfNeeded(ayaInfo);
                  DownloadAyaIfNeeded(nextAyaInfo);

                  AppendMp3ToFileStream(FullAyaFileName(FileNameForAya(ayaInfo)), fs);
                  var gapSeconds = GetGapForAya(ayaInfo, dynamicGap, nextAyaInfo, navItem.IsRevision);
                  for(int gapNumber = 0; gapNumber < gapSeconds; gapNumber++)
                  {
                     //AppendMp3ToFileStream(FullAyaFileName("blank.mp3"), fs);
                     blankAudioOneSecondStream.Seek(0, SeekOrigin.Begin);
                     blankAudioOneSecondStream.CopyTo(fs);
                     Application.DoEvents();
                  }

                  Application.DoEvents();
               }

               fs.Flush();
            }

            totalProgressBar.Value = Math.Min(100, 100 * currentDay / navItems.Count);
            Application.DoEvents();
         }

         Done();
      }

      private void AppendMp3ToFileStream(string mp3File, FileStream fs)
      {
         var buffer = File.ReadAllBytes(mp3File);
         fs.Write(buffer, 0, buffer.Length);
      }

      private string FullAyaFileName(string ayaFile)
      {
         return Path.Combine(stageDir, ayaFile);
      }

      private int GetGapForAya(AyaInfo aya, DynamicGap dynamicGap, AyaInfo nextAya, bool isRevision)
      {
         var currentAyaFile = FullAyaFileName(FileNameForAya(aya));
         var nextAyaFile = FullAyaFileName(FileNameForAya(nextAya));
         var currentAyaDuration = new Mp3FileReader(currentAyaFile).TotalTime.TotalSeconds;
         var nextAyaDuration = new Mp3FileReader(nextAyaFile).TotalTime.TotalSeconds;
         var usedDuration = isRevision ? nextAyaDuration : currentAyaDuration;
         double result;

         switch(dynamicGap)
         {
            case DynamicGap.AyaDurationHalf:
               result = usedDuration * 0.5f;
               break;
            case DynamicGap.AyaDurationOne:
               result = usedDuration * 1f;
               break;
            case DynamicGap.AyaDuratioOneAndHalf:
               result = usedDuration * 1.5f;
               break;

            case DynamicGap.NoGap:
            default:
               result = 0;
               break;
         }

         return (int) (result + 0.5);
      }

      public static string FileNameForAya(AyaInfo aya)
      {
         var suraStr = ThreeDigit(aya.suraNumber.ToString());
         var ayaStr = ThreeDigit(aya.ayaNumber.ToString());
        return string.Format("{0}{1}.mp3", suraStr, ayaStr);
      }

      static List<AyaInfo> GetRangeAyaList(AyaRange ayaRange)
      {
         var result = new List<AyaInfo>();
         var currentSura = ayaRange.startAyaInfo.suraNumber;
         var currentAya = ayaRange.startAyaInfo.ayaNumber;

         do
         {
            result.Add(AyaInfo.Create(currentSura, currentAya));

            if (currentAya < QuranArrayHelper.SURA_NUM_AYAHS[currentSura - 1])
            {
               currentAya++;
            }
            else
            {
               currentSura++;
               currentAya = 1;
            }

         } while (AyaUtil.AyaTotalRank(AyaInfo.Create(currentSura, currentAya)) <= AyaUtil.AyaTotalRank(ayaRange.endAyaInfo));

         return result;
      }

      private static string ThreeDigit(string s)
      {
         string result = s;
         while (result.Length < 3)
         {
            result = "0" + result;
         }

         return result;
      }

      private static void CleanDirectory(string dir)
      {
         if(Directory.Exists(dir) == false)
         {
            Directory.CreateDirectory(dir);
            return;
         }

         DirectoryInfo di = new DirectoryInfo(dir);
         foreach (FileInfo file in di.EnumerateFiles()) file.Delete();
         foreach (DirectoryInfo subDirectory in di.EnumerateDirectories()) subDirectory.Delete(true);
      }

      private void DownloadAyaIfNeeded(AyaInfo ayaInfo)
      {
         var ayaLocalFile = FullAyaFileName(FileNameForAya(ayaInfo));
         if (File.Exists(ayaLocalFile)) return;

         using (var client = new WebClient())
         {
            downloadCompleted = false;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(RecitersUtility.GetURLForAyah(reciter, ayaInfo.suraNumber, ayaInfo.ayaNumber)), ayaLocalFile);
            while (downloadCompleted == false)
            {
               Application.DoEvents();
            }
         }
      }

      private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
      {
         downloadCompleted = true;
      }

      private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
      {
         downloadProgressBar.Value = e.ProgressPercentage;
      }
   }
}

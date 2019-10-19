using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace QuranMemorizeMp3Tool
{
   public enum DynamicGap
   {
      NoGap,
      AyaDuration20Percent,
      AyaDuration40Percent,
      AyaDuration60Percent,
      AyaDuration80Percent,
      AyaDurationOne,
      AyaDuration120Percent,
      AyaDuration140Percent,
      AyaDuration160Percent,
      AyaDuration180Percent,
      AyaDuration200Percent,
   }

   class AudioFile
   {
      public string FileName { get; set; }
      public float Volume { get; set; }

      public AudioFile(string fileName, float volume = 0.5f)
      {
         FileName = fileName;
         Volume = volume;
      }
   }
   class QuranMp3JoinUtil
   {
      public bool Processing { get; private set; }

      private Reciter reciter;
      private string dstDir;
      private ProgressBar downloadProgressBar;
      private ProgressBar totalProgressBar;
      private bool downloadCompleted;

      private const string stageDir = "stage";
      private const string blankOneSecondBaseUrl = "https://archive.org/download/ahmedneana128kbps/";
      
      public QuranMp3JoinUtil(Reciter reciter, string dstDir, ProgressBar downloadProgressBar, ProgressBar totalProgressBar)
      {
         this.reciter = reciter;
         this.dstDir = dstDir;
         this.downloadProgressBar = downloadProgressBar;
         this.totalProgressBar = totalProgressBar;
      }

      public void Done()
      {
         Thread.Sleep(500);
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

         var blankOneSecondUrl = blankOneSecondBaseUrl + reciter.BlankResourceName;
         var blankOneSecondLocalFile = Path.Combine(stageDir, reciter.BlankResourceName);
         using (var blankDownloadWebClient = new WebClient())
         {
            blankDownloadWebClient.DownloadFile(blankOneSecondUrl, blankOneSecondLocalFile);
         }

         int currentDay = 1;
         foreach (var navItem in navItems)
         {
            if (Processing == false) break;

            var outFileName = Path.Combine(dstDir, string.Format("day_{0}_{1}.mp3", currentDay++, navItem.Title));
            var allFiles = new List<AudioFile>();

            if (Processing == false) break;

            var ayaInfos = GetRangeAyaList(navItem.rangeOfAyas);
            DownloadAyaIfNeeded(ayaInfos[0]);
            foreach (var ayaInfo in ayaInfos)
            {
               var isLastAya = ayaInfo.EqualsAya(ayaInfos[ayaInfos.Count - 1]);
               var nextAyaInfo = isLastAya ? ayaInfo : AyaUtil.GetNextAyaInfoFromCurrent(ayaInfo);

               if (isLastAya == false)
               {
                  DownloadAyaIfNeeded(nextAyaInfo);
               }

               allFiles.Add(new AudioFile(FullAyaFileName(FileNameForAya(ayaInfo))));
               var gapSeconds = GetGapForAya(ayaInfo, dynamicGap, nextAyaInfo, navItem.IsRevision) + fixedGap;
               for (int gapNumber = 0; gapNumber < gapSeconds; gapNumber++)
               {
                  allFiles.Add(new AudioFile(blankOneSecondLocalFile));

                  Application.DoEvents();
               }

               Application.DoEvents();
            }


            Combine(allFiles, outFileName);

            totalProgressBar.Value = Math.Min(100, 100 * currentDay / navItems.Count);
            Application.DoEvents();
         }

         Done();
      }

      private string FullAyaFileName(string ayaFile)
      {
         return Path.Combine(stageDir, ayaFile);
      }

      private int GetGapForAya(AyaInfo aya, DynamicGap dynamicGap, AyaInfo nextAya, bool isRevision)
      {
         var currentAyaFile = FullAyaFileName(FileNameForAya(aya));
         var nextAyaFile = FullAyaFileName(FileNameForAya(nextAya));
         var currentAyaDuration = GetMediaDuration(currentAyaFile);
         var nextAyaDuration = GetMediaDuration(nextAyaFile);
         var usedDuration = isRevision ? nextAyaDuration : currentAyaDuration;
         double result;
         int minGap = 1;

         switch(dynamicGap)
         {
            case DynamicGap.AyaDuration20Percent:
               result = usedDuration * 0.2f;
               break;
            case DynamicGap.AyaDuration40Percent:
               result = usedDuration * 0.4f;
               break;
            case DynamicGap.AyaDuration60Percent:
               result = usedDuration * 0.6f;
               break;
            case DynamicGap.AyaDuration80Percent:
               result = usedDuration * 0.8f;
               break;
            case DynamicGap.AyaDurationOne:
               result = usedDuration * 1f;
               break;
            case DynamicGap.AyaDuration120Percent:
               result = usedDuration * 1.2f;
               break;
            case DynamicGap.AyaDuration140Percent:
               result = usedDuration * 1.4f;
               break;
            case DynamicGap.AyaDuration160Percent:
               result = usedDuration * 1.6f;
               break;
            case DynamicGap.AyaDuration200Percent:
               result = usedDuration * 2f;
               break;

            case DynamicGap.NoGap:
            default:
               result = 0;
               minGap = 0;
               break;
         }

         return Math.Max(minGap, (int) (result + 0.5));
      }

      double GetMediaDuration(string MediaFileName)
      {
         double duration = 0.0;
         bool nAudioSuccess;

         try
         {
            using(var reader = new Mp3FileReader(MediaFileName))
            {
               duration = reader.TotalTime.TotalSeconds;
            }

            nAudioSuccess = true;
         }
         catch(Exception ex)
         {
            nAudioSuccess = false;
         }

         if (nAudioSuccess) return duration;

         using (FileStream fs = File.OpenRead(MediaFileName))
         {
            Mp3Frame frame = Mp3Frame.LoadFromStream(fs);

            while (frame != null)
            {
               if (frame.ChannelMode == ChannelMode.Mono)
               {
                  duration += (double)frame.SampleCount * 2.0 / (double)frame.SampleRate;
               }
               else
               {
                  duration += (double)frame.SampleCount * 4.0 / (double)frame.SampleRate;
               }
               frame = Mp3Frame.LoadFromStream(fs);
            }
         }
         return duration / 4;
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

      public void Combine(List<AudioFile> inputFiles, string outputFile)
      {
         using (var fs = File.OpenWrite(outputFile))
         {
            foreach (var file in inputFiles)
            {
               if (Processing == false) break;

               Application.DoEvents();
               Mp3FileReader reader = new Mp3FileReader(file.FileName);
               if ((fs.Position == 0) && (reader.Id3v2Tag != null))
               {
                  fs.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
               }
               Mp3Frame frame;
               while ((frame = reader.ReadNextFrame()) != null)
               {
                  fs.Write(frame.RawData, 0, frame.RawData.Length);
               }
            }
         }
      }
   }
}

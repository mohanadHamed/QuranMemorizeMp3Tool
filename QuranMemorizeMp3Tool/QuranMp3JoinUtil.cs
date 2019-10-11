using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranMemorizeMp3Tool
{
   class QuranMp3JoinUtil
   {
      private string srcDir;
      private string dstDir;

      public QuranMp3JoinUtil(string srcDir, string dstDir)
      {
         this.srcDir = srcDir;
         this.dstDir = dstDir;

      }
      public void GenerateJoinedMp3(int juz, DynamicGap dynamicGap, decimal fixedGap, System.Windows.Forms.ProgressBar progressBar)
      {
         var navItems = QuranDailyPlanUtil.GetAllNavigationItems(juz);
         var blankAudioOneSecondStream = Assembly.GetEntryAssembly().GetManifestResourceStream("QuranMemorizeMp3Tool.blank_one_sec.mp3");
         
         int currentDay = 1;
         foreach (var navItem in navItems)
         {
            var outFileName = Path.Combine(dstDir, string.Format("day_{0}_{1}.mp3", currentDay++, navItem.Title));
            using (var fs = File.OpenWrite(outFileName))
            {
               var ayaInfos = GetRangeAyaList(navItem.rangeOfAyas);
               foreach (var ayaInfo in ayaInfos)
               {
                  AppendMp3ToFileStream(FullAyaFileName(FileNameForAya(ayaInfo)), fs);
                  var gapSeconds = GetGapForAya(ayaInfo, dynamicGap, ayaInfo.EqualsAya(ayaInfos[ayaInfos.Count - 1]));
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

            progressBar.Value = Math.Min(100, 100 * currentDay / navItems.Count);
            Application.DoEvents();
         }
      }

      private void AppendMp3ToFileStream(string mp3File, FileStream fs)
      {
         var buffer = File.ReadAllBytes(mp3File);
         fs.Write(buffer, 0, buffer.Length);
      }

      private string FullAyaFileName(string ayaFile)
      {
         return Path.Combine(srcDir, ayaFile);
      }

      private int GetGapForAya(AyaInfo aya, DynamicGap dynamicGap, bool isLastAya)
      {
         var nextAya = isLastAya ? aya : AyaUtil.GetNextAyaInfoFromCurrent(aya);
         var currentAyaFile = FullAyaFileName(FileNameForAya(aya));
         var nextAyaFile = FullAyaFileName(FileNameForAya(nextAya));
         var currentAyaDuration = new Mp3FileReader(currentAyaFile).TotalTime.TotalSeconds;
         var nextAyaDuration = new Mp3FileReader(nextAyaFile).TotalTime.TotalSeconds;
         double result;

         switch(dynamicGap)
         {
            case DynamicGap.CurrentAyaDurationHalf:
               result = currentAyaDuration * 0.5f;
               break;
            case DynamicGap.CurrentAyaDurationOne:
               result = currentAyaDuration * 1f;
               break;
            case DynamicGap.CurrentAyaDuratioOneAndHalf:
               result = currentAyaDuration * 1.5f;
               break;
            case DynamicGap.CurrentAyaDurationTwo:
               result = currentAyaDuration * 2f;
               break;
            case DynamicGap.NextAyaDurationHalf:
               result = nextAyaDuration * 0.5f;
               break;
            case DynamicGap.NextAyaDurationOne:
               result = nextAyaDuration * 1f;
               break;
            case DynamicGap.NextAyaDuratioOneAndHalf:
               result = nextAyaDuration * 1.5f;
               break;
            case DynamicGap.NextAyaDurationTwo:
            default:
               result = nextAyaDuration * 2f;
               break;
         }

         return (int) (result + 0.5);
      }

      private static string FileNameForAya(AyaInfo aya)
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

      static string ThreeDigit(string s)
      {
         string result = s;
         while (result.Length < 3)
         {
            result = "0" + result;
         }

         return result;
      }
   }
}

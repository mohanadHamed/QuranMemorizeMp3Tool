using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranMemorizeMp3Tool
{
   class QuranMp3JoinUtil
   {
      public static void GenerateJoinedMp3(string srcDir, string dstDir, int juz, DynamicGap dynamicGap, decimal fixedGap)
      {
         var navItems = QuranDailyPlanUtil.GetAllNavigationItems(juz);
         foreach (var navItem in navItems)
         {
            var files = GetAyaFileList(navItem.rangeOfAyas);
         }
      }

      static List<string> GetAyaFileList(AyaRange ayaRange)
      {
         var result = new List<string>();
         var currentSura = ayaRange.startAyaInfo.suraNumber;
         var currentAya = ayaRange.startAyaInfo.ayaNumber;

         do
         {
            var suraStr = ThreeDigit(currentSura.ToString());
            var ayaStr = ThreeDigit(currentAya.ToString());
            var fileName = string.Format("{0}{1}.mp3", suraStr, ayaStr);
            result.Add(fileName);

            if (currentAya < QuranArrayHelper.SURA_NUM_AYAHS[currentSura])
            {
               currentAya++;
            }
            else
            {
               currentSura++;
               currentAya = 1;
            }

         } while (AyaUtil.AyaTotalRank(new AyaInfo() { suraNumber = currentSura, ayaNumber = currentAya })
                  <= AyaUtil.AyaTotalRank(new AyaInfo() { suraNumber = ayaRange.endAyaInfo.suraNumber, ayaNumber = ayaRange.endAyaInfo.ayaNumber }));

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranMemorizeMp3Tool
{
   class AyaUtil
   {
      public static int AyaTotalRank(AyaInfo info)
      {
         return (info.suraNumber * 1000) + info.ayaNumber;
      }

      public static AyaInfo MinimumAyaRange(AyaInfo ayaInfo1, AyaInfo ayaInfo2)
      {
         return AyaTotalRank(ayaInfo1) < AyaTotalRank(ayaInfo2) ? ayaInfo1 : ayaInfo2;
      }

      public static AyaInfo MaximumAyaRange(AyaInfo ayaInfo1, AyaInfo ayaInfo2)
      {
         return AyaTotalRank(ayaInfo1) > AyaTotalRank(ayaInfo2) ? ayaInfo1 : ayaInfo2;
      }

      public static AyaInfo GetPreviousAyaInfoFromCurrent(AyaInfo currentAyaInfo)
      {
         AyaInfo result = new AyaInfo();

         if (currentAyaInfo.suraNumber == 1 && currentAyaInfo.ayaNumber == 1)
         {
            result.suraNumber = currentAyaInfo.suraNumber;
            result.ayaNumber = currentAyaInfo.ayaNumber;
         }
         else
         {
            if (currentAyaInfo.ayaNumber > 1)
            {
               result.suraNumber = currentAyaInfo.suraNumber;
               result.ayaNumber = currentAyaInfo.ayaNumber - 1;
            }
            else
            {
               result.suraNumber = currentAyaInfo.suraNumber - 1;
               result.ayaNumber = QuranArrayHelper.suraNumAyas[result.suraNumber - 1];
            }
         }

         return result;
      }

      public static AyaInfo GetNextAyaInfoFromCurrent(AyaInfo currentAyaInfo)
      {
         AyaInfo result = new AyaInfo();

         if (currentAyaInfo.suraNumber == 114 && currentAyaInfo.ayaNumber == 6)
         {
            result.suraNumber = currentAyaInfo.suraNumber;
            result.ayaNumber = currentAyaInfo.ayaNumber;
         }
         else
         {
            if (currentAyaInfo.ayaNumber < QuranArrayHelper.suraNumAyas[currentAyaInfo.suraNumber - 1])
            {
               result.suraNumber = currentAyaInfo.suraNumber;
               result.ayaNumber = currentAyaInfo.ayaNumber + 1;
            }
            else
            {
               result.suraNumber = currentAyaInfo.suraNumber + 1;
               result.ayaNumber = 1;
            }
         }

         return result;
      }
   }
}

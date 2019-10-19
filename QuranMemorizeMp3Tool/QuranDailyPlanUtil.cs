using System;
using System.Collections.Generic;

namespace QuranMemorizeMp3Tool
{
   class QuranDailyPlanUtil
   {
      static int GetMemorizeDayInfoCount(int juz)
      {
         return JuzEndPageNumber(juz) - QuranArrayHelper.juzPageStart[juz-1] + 1;
      }

      static AyaRange GetMergedAyaRange(MemorizeDayInfo item1, MemorizeDayInfo item2)
      {
         AyaRange result = new AyaRange();

         result.startAyaInfo = AyaUtil.MinimumAyaRange(item1.rangeOfAyas.startAyaInfo, item2.rangeOfAyas.startAyaInfo);
         result.endAyaInfo = AyaUtil.MaximumAyaRange(item1.rangeOfAyas.endAyaInfo, item2.rangeOfAyas.endAyaInfo);

         return result;
      }

      static int JuzEndPageNumber(int juz)
      {
         if(juz < 30)
         {
            return QuranArrayHelper.juzPageStart[juz] - 1;
         }

         return 604;
      }

      public static List<MemorizeDayInfo> GetAllNavigationItems(int juz)
      {
         List<MemorizeDayInfo> result = new List<MemorizeDayInfo>();
         int itemsCount = GetMemorizeDayInfoCount(juz);
         int finalIndex;
         int dailyPlanStartPageIndex = QuranArrayHelper.juzPageStart[juz - 1] - 1;
         
         for (int i = 0; i < itemsCount; i++)
         {
            finalIndex = dailyPlanStartPageIndex + i;
            MemorizeDayInfo navItem = new MemorizeDayInfo();

            navItem.rangeOfAyas = QuranArrayHelper.GetAyaRangeFromGeneralIndex(finalIndex);
            navItem.Title = string.Format("juz_{0}_page_{1}", juz, finalIndex + 1);

            result.Add(navItem);
         }

         result = GetDailyPlanWithRevisionItems(result, juz);

         return result;
      }

      static MemorizeDayInfo GetLastfivePagesNavItem(List<MemorizeDayInfo> orgItems, int currentNavItemIndex)
      {
         MemorizeDayInfo navItem = new MemorizeDayInfo();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         int minItem = Math.Max(0, currentNavItemIndex - 4);
         navItem.Title = GetRevisionTitleAccordingToNumberOfPages(minItem, currentNavItemIndex);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[currentNavItemIndex]);
         navItem.IsRevision = true;
         return navItem;
      }

      static void AddJuzRevisionItemsPerHizb(List<MemorizeDayInfo> orgItems, List<MemorizeDayInfo> result, int startItem, int endItem, int juz)
      {
         MemorizeDayInfo navItem;
         int minItem, maxItem, count;

         count = endItem - startItem + 1;
         navItem = new MemorizeDayInfo();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem;
         maxItem = startItem + count / 2 - 1;
         navItem.Title = string.Format("hizb{0}_revision", juz * 2 - 1);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);

         navItem = new MemorizeDayInfo();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem + count / 2;
         maxItem = endItem;
         navItem.Title = string.Format("hizb{0}_revision", juz * 2);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);
      }

      static void AddFullJuzRevisionItems(List<MemorizeDayInfo> orgItems, List<MemorizeDayInfo> result, int startItem, int endItem, int juz)
      {
         MemorizeDayInfo navItem;
         int minItem, maxItem;

         navItem = new MemorizeDayInfo();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem;
         maxItem = endItem;
         navItem.Title = string.Format("juz{0}_revision", juz);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);
      }

      static string GetRevisionTitleAccordingToNumberOfPages(int startPage, int endPage)
      {
         int count = endPage - startPage + 1;
         string result = "revise_last_";
         result += (count.ToString() + "_pages");
         return result;
      }

      static List<MemorizeDayInfo> GetDailyPlanWithRevisionItems(List<MemorizeDayInfo> orgItems, int juz)
      {
         List<MemorizeDayInfo> result = new List<MemorizeDayInfo>();

         // string prefix = "";
         for (int i = 0; i < orgItems.Count; i++)
         {
            //prefix = Convert.ToString(result.Count + 1) + "- ";
            MemorizeDayInfo unchangedNavItem = orgItems[i];

            result.Add(unchangedNavItem);

            result.Add(GetLastfivePagesNavItem(orgItems, i));

            if (i == orgItems.Count - 1)
            {
               for (int k = 0; k < 4; k++)
               {
                  result.Add(GetLastfivePagesNavItem(orgItems, i));
               }
            }
         }

         int startItem = 0;
         int endItem = orgItems.Count - 1;
         AddJuzRevisionItemsPerHizb(orgItems, result, startItem, endItem, juz);
         AddJuzRevisionItemsPerHizb(orgItems, result, startItem, endItem, juz);
         AddJuzRevisionItemsPerHizb(orgItems, result, startItem, endItem, juz);
         AddFullJuzRevisionItems(orgItems, result, startItem, endItem, juz);

         return result;
      }

   }
}

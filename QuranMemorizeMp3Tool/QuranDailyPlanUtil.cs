using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranMemorizeMp3Tool
{
   class QuranDailyPlanUtil
   {
      const int MAX_PAGES_PER_JUZ = 23;

      static int GetMemorizeNavigationItemsCount(int juz)
      {
         return JuzEndPageNumber(juz) - QuranArrayHelper.JUZ_PAGE_START[juz-1] + 1;
      }

      static AyaRange GetMergedAyaRangeForDailyPlan(bool extraPrevAyah, MemorizeNavigationItem item1, MemorizeNavigationItem item2)
      {

         AyaRange result = GetMergedAyaRange(item1, item2);

         if (extraPrevAyah)
         {
            result.startAyaInfo = AyaUtil.GetPreviousAyaInfoFromCurrent(result.startAyaInfo);
         }

         return result;
      }

      static AyaRange GetMergedAyaRange(MemorizeNavigationItem item1, MemorizeNavigationItem item2)
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
            return QuranArrayHelper.JUZ_PAGE_START[juz] - 1;
         }

         return 604;
      }

      public static List<MemorizeNavigationItem> GetAllNavigationItems(int juz)
      {
         List<MemorizeNavigationItem> result = new List<MemorizeNavigationItem>();
         int itemsCount = GetMemorizeNavigationItemsCount(juz);
         int finalIndex;
         int dailyPlanStartPageIndex = QuranArrayHelper.JUZ_PAGE_START[juz - 1] - 1;
         
         for (int i = 0; i < itemsCount; i++)
         {
            finalIndex = dailyPlanStartPageIndex + i;
            MemorizeNavigationItem navItem = new MemorizeNavigationItem();

            navItem.rangeOfAyas = QuranArrayHelper.GetAyaRangeFromGeneralIndex(finalIndex);
            navItem.Title = GetNavigationItemTitle(navItem, CategorizeType.ByDailyPlan, finalIndex, juz);

            result.Add(navItem);
         }

         result = GetDailyPlanWithRevisionItems(result, juz);

         return result;
      }

      static MemorizeNavigationItem GetLastfivePagesNavItem(List<MemorizeNavigationItem> orgItems, int currentNavItemIndex)
      {
         MemorizeNavigationItem navItem = new MemorizeNavigationItem();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         int minItem = Math.Max(0, currentNavItemIndex - 4);
         navItem.Title = GetRevisionTitleAccordingToNumberOfPages(minItem, currentNavItemIndex);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[currentNavItemIndex]);
         navItem.IsRevision = true;
         return navItem;
      }

      static void AddJuzRevisionItemsPerHizb(List<MemorizeNavigationItem> orgItems, List<MemorizeNavigationItem> result, int startItem, int endItem, int juz)
      {
         MemorizeNavigationItem navItem;
         int minItem, maxItem, count;

         count = endItem - startItem + 1;
         navItem = new MemorizeNavigationItem();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem;
         maxItem = startItem + count / 2 - 1;
         navItem.Title = string.Format("hizb{0} revision", juz * 2 - 1);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);

         navItem = new MemorizeNavigationItem();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem + count / 2;
         maxItem = endItem;
         navItem.Title = string.Format("hizb{0} revision", juz * 2);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);
      }

      static void AddFullJuzRevisionItems(List<MemorizeNavigationItem> orgItems, List<MemorizeNavigationItem> result, int startItem, int endItem, int juz)
      {
         MemorizeNavigationItem navItem;
         int minItem, maxItem;

         navItem = new MemorizeNavigationItem();
         //prefix = Convert.ToString(result.Count + 1) + "- ";
         minItem = startItem;
         maxItem = endItem;
         navItem.Title = string.Format("juz{0} revision", juz);
         navItem.rangeOfAyas = GetMergedAyaRange(orgItems[minItem], orgItems[maxItem]);
         navItem.IsRevision = true;
         result.Add(navItem);
      }

      static string GetRevisionTitleAccordingToNumberOfPages(int startPage, int endPage)
      {
         int count = endPage - startPage + 1;
         string result = "Revise last ";
         result += (count.ToString() + " pages");
         return result;
      }

      static List<MemorizeNavigationItem> GetDailyPlanWithRevisionItems(List<MemorizeNavigationItem> orgItems, int juz)
      {
         List<MemorizeNavigationItem> result = new List<MemorizeNavigationItem>();

         // string prefix = "";
         for (int i = 0; i < orgItems.Count; i++)
         {
            //prefix = Convert.ToString(result.Count + 1) + "- ";
            MemorizeNavigationItem unchangedNavItem = orgItems[i];
            //if(i > 0)
            //{
            //	unchangedNavItem.rangeOfAyas.startAyaInfo = AyaUtil.GetPreviousAyaInfoFromCurrent(unchangedNavItem.rangeOfAyas.startAyaInfo);
            //}
            //unchangedNavItem.Title = /*prefix + */unchangedNavItem.Title;

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

      static string GetNavigationItemTitle(MemorizeNavigationItem navItem, CategorizeType categorizeType, int generalIndex, int juz)
      {
         return string.Format("juz_{0}_page_{1}", juz, generalIndex + 1);
      }

   }
}

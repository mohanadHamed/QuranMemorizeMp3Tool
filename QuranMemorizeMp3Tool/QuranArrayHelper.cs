using System.Collections.Generic;

namespace QuranMemorizeMp3Tool
{
   public class QuarterHizbEndInfo
   {
      public int suraNumber;
      public int ayaNumber;

      public QuarterHizbEndInfo(int suraNum, int ayaNum)
      {
         suraNumber = suraNum;
         ayaNumber = ayaNum;
      }
   }


   public enum CategorizeType
   {
      BySura,
      ByPage,
      ByJuz,
      ByHizb,
      ByHalfHizb,
      ByQuarterHizb,
      ByDailyPlan
   }

   public struct AyaRange
   {
      public AyaInfo startAyaInfo;

      public AyaInfo endAyaInfo;
   }

   public struct AyaInfo
   {
      public int suraNumber;

      public int ayaNumber;

      public bool EqualsAya(AyaInfo info)
      {
         return info.ayaNumber == ayaNumber && info.suraNumber == suraNumber;
      }

      public static AyaInfo Create(int sura, int aya)
      {
         return new AyaInfo() { suraNumber = sura, ayaNumber = aya };
      }
   }

   public static class QuranArrayHelper
   {

      public static string[] SURA_NAMES_EN = {
      "Al-Fatiha", "Al-Baqara", "Aal-E-Imran", "An-Nisa", "Al-Maeda",
      "Al-Anaam", "Al-Araf", "Al-Anfal", "At-Tawba", "Yunus", "Hud",
      "Yusuf", "Ar-Rad", "Ibrahim", "Al-Hijr", "An-Nahl", "Al-Isra",
      "Al-Kahf", "Maryam", "Ta-Ha", "Al-Anbiya", "Al-Hajj", "Al-Mumenoon",
      "An-Noor", "Al-Furqan", "Ash-Shu'ara", "An-Naml", "Al-Qasas",
      "Al-Ankaboot", "Ar-Room", "Luqman", "As-Sajda", "Al-Ahzab", "Saba",
      "Fatir", "Ya-Seen", "As-Saaffat", "Sad", "Az-Zumar", "Ghafir",
      "Fussilat", "Ash-Shura", "Az-Zukhruf", "Ad-Dukhan", "Al-Jathiya",
      "Al-Ahqaf", "Muhammad", "Al-Fath", "Al-Hujraat", "Qaf",
      "Adh-Dhariyat", "At-Tur", "An-Najm", "Al-Qamar", "Ar-Rahman",
      "Al-Waqia", "Al-Hadid", "Al-Mujadila", "Al-Hashr", "Al-Mumtahina",
      "As-Saff", "Al-Jumua", "Al-Munafiqoon", "At-Taghabun", "At-Talaq",
      "At-Tahrim", "Al-Mulk", "Al-Qalam", "Al-Haaqqa", "Al-Maarij", "Nooh",
      "Al-Jinn", "Al-Muzzammil", "Al-Muddaththir", "Al-Qiyama", "Al-Insan",
      "Al-Mursalat", "An-Naba", "An-Naziat", "Abasa", "At-Takwir",
      "Al-Infitar", "Al-Mutaffifin", "Al-Inshiqaq", "Al-Burooj", "At-Tariq",
      "Al-Ala", "Al-Ghashiya", "Al-Fajr", "Al-Balad", "Ash-Shams",
      "Al-Lail", "Ad-Dhuha", "Al-Inshirah", "At-Tin", "Al-Alaq", "Al-Qadr",
      "Al-Bayyina", "Az-Zalzala", "Al-Adiyat", "Al-Qaria", "At-Takathur",
      "Al-Asr", "Al-Humaza", "Al-Fil", "Quraish", "Al-Maun", "Al-Kauther",
      "Al-Kafiroon", "An-Nasr", "Al-Masadd", "Al-Ikhlas", "Al-Falaq",
      "An-Nas"
   };

      public static string[] SURA_NAMES_AR = {
      "الفاتحة", "البقرة", "آل عمران", "النساء", "المائدة",
      "الانعام", "الاعراف", "الانفال", "التوبة", "يونس", "هود",
      "يوسف", "الرعد", "إبراهيم", "الحجر", "النحل", "الاسراء",
      "الكهف", "مريم", "طه", "الانبياء", "الحج", "المؤمنون",
      "النور", "الفرقان", "الشعراء", "النمل", "القصص",
      "العنكبوت", "الروم", "لقمان", "السجدة", "الاحزاب", "سبأ",
      "فاطر", "يس", "الصافات", "ص", "الزمر", "غافر",
      "فصلت", "الشورى", "الزخرف", "الدخان", "الجاثية",
      "الاحقاف", "محمد", "الفتح", "الحجرات", "ق",
      "الذاريات", "الطور", "النجم", "القمر", "الرحمن",
      "الواقعة", "الحديد", "المجادلة", "الحشر", "الممتحنة",
      "الصف", "الجمعة", "المنافقون", "التغابن", "الطلاق",
      "التحريم", "الملك", "القلم", "الحاقة", "المعارج", "نوح",
      "الجن", "المزمل", "المدثر", "القيامة", "الانسان",
      "المرسلات", "النبأ", "النازعات", "عبس", "التكوير",
      "الانفطار", "المطففين", "الانشقاق", "البروج", "الطارق",
      "الاعلى", "الغاشية", "الفجر", "البلد", "الشمس",
      "الليل", "الضحى", "الشرح", "التين", "العلق", "القدر",
      "البينة", "الزلزلة", "العاديات", "القارعة", "التكاثر",
      "العصر", "الهمزة", "الفيل", "قريش", "الماعون", "الكوثر",
      "الكافرون", "النصر", "المسد", "الاخلاص", "الفلق",
      "الناس"
   };

      public static int[] SURA_PAGE_START = {
        1, 2, 50, 77, 106, 128, 151, 177, 187, 208, 221, 235, 249, 255, 262,
        267, 282, 293, 305, 312, 322, 332, 342, 350, 359, 367, 377, 385, 396,
        404, 411, 415, 418, 428, 434, 440, 446, 453, 458, 467, 477, 483, 489,
        496, 499, 502, 507, 511, 515, 518, 520, 523, 526, 528, 531, 534, 537,
        542, 545, 549, 551, 553, 554, 556, 558, 560, 562, 564, 566, 568, 570,
        572, 574, 575, 577, 578, 580, 582, 583, 585, 586, 587, 587, 589, 590,
        591, 591, 592, 593, 594, 595, 595, 596, 596, 597, 597, 598, 598, 599,
        599, 600, 600, 601, 601, 601, 602, 602, 602, 603, 603, 603, 604, 604,
        604
    };

      public static int[] PAGE_SURA_START = {
        1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
        3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
        5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
        6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
        7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9,
        9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10,
        10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11,
        11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13,
        13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 16,
        16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17,
        17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18,
        19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21,
        21, 21, 21, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22,
        22, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24,
        24, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
        27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 28, 28, 28,
        28, 28, 29, 29, 29, 29, 29, 29, 29, 29, 30, 30, 30, 30, 30, 30, 31, 31,
        31, 31, 32, 32, 32, 33, 33, 33, 33, 33, 33, 33, 33, 33, 33, 34, 34, 34,
        34, 34, 34, 34, 35, 35, 35, 35, 35, 35, 36, 36, 36, 36, 36, 37, 37, 37,
        37, 37, 37, 37, 38, 38, 38, 38, 38, 38, 39, 39, 39, 39, 39, 39, 39, 39,
        39, 40, 40, 40, 40, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 41, 42, 42,
        42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 44, 44, 44, 45, 45, 45, 45,
        46, 46, 46, 46, 47, 47, 47, 47, 48, 48, 48, 48, 48, 49, 49, 50, 50, 50,
        51, 51, 51, 52, 52, 53, 53, 53, 54, 54, 54, 55, 55, 55, 56, 56, 56, 57,
        57, 57, 57, 58, 58, 58, 58, 59, 59, 59, 60, 60, 60, 61, 62, 62, 63, 64,
        64, 65, 65, 66, 66, 67, 67, 67, 68, 68, 69, 69, 70, 70, 71, 72, 72, 73,
        73, 74, 74, 75, 76, 76, 77, 78, 78, 79, 80, 81, 82, 83, 83, 85, 86, 87,
        89, 89, 91, 92, 95, 97, 98, 100, 103, 106, 109, 112
    };

      public static int[] PAGE_AYAH_START = {
        1, 1, 6, 17, 25, 30, 38, 49, 58, 62, 70, 77, 84, 89, 94, 102, 106, 113,
        120, 127, 135, 142, 146, 154, 164, 170, 177, 182, 187, 191, 197, 203,
        211, 216, 220, 225, 231, 234, 238, 246, 249, 253, 257, 260, 265, 270,
        275, 282, 283, 1, 10, 16, 23, 30, 38, 46, 53, 62, 71, 78, 84, 92, 101,
        109, 116, 122, 133, 141, 149, 154, 158, 166, 174, 181, 187, 195, 1, 7,
        12, 15, 20, 24, 27, 34, 38, 45, 52, 60, 66, 75, 80, 87, 92, 95, 102,
        106, 114, 122, 128, 135, 141, 148, 155, 163, 171, 176, 3, 6, 10, 14,
        18, 24, 32, 37, 42, 46, 51, 58, 65, 71, 77, 83, 90, 96, 104, 109, 114,
        1, 9, 19, 28, 36, 45, 53, 60, 69, 74, 82, 91, 95, 102, 111, 119, 125,
        132, 138, 143, 147, 152, 158, 1, 12, 23, 31, 38, 44, 52, 58, 68, 74,
        82, 88, 96, 105, 121, 131, 138, 144, 150, 156, 160, 164, 171, 179, 188,
        196, 1, 9, 17, 26, 34, 41, 46, 53, 62, 70, 1, 7, 14, 21, 27, 32, 37,
        41, 48, 55, 62, 69, 73, 80, 87, 94, 100, 107, 112, 118, 123, 1, 7, 15,
        21, 26, 34, 43, 54, 62, 71, 79, 89, 98, 107, 6, 13, 20, 29, 38, 46, 54,
        63, 72, 82, 89, 98, 109, 118, 5, 15, 23, 31, 38, 44, 53, 64, 70, 79,
        87, 96, 104, 1, 6, 14, 19, 29, 35, 43, 6, 11, 19, 25, 34, 43, 1, 16,
        32, 52, 71, 91, 7, 15, 27, 35, 43, 55, 65, 73, 80, 88, 94, 103, 111,
        119, 1, 8, 18, 28, 39, 50, 59, 67, 76, 87, 97, 105, 5, 16, 21, 28, 35,
        46, 54, 62, 75, 84, 98, 1, 12, 26, 39, 52, 65, 77, 96, 13, 38, 52, 65,
        77, 88, 99, 114, 126, 1, 11, 25, 36, 45, 58, 73, 82, 91, 102, 1, 6,
        16, 24, 31, 39, 47, 56, 65, 73, 1, 18, 28, 43, 60, 75, 90, 105, 1,
        11, 21, 28, 32, 37, 44, 54, 59, 62, 3, 12, 21, 33, 44, 56, 68, 1, 20,
        40, 61, 84, 112, 137, 160, 184, 207, 1, 14, 23, 36, 45, 56, 64, 77,
        89, 6, 14, 22, 29, 36, 44, 51, 60, 71, 78, 85, 7, 15, 24, 31, 39, 46,
        53, 64, 6, 16, 25, 33, 42, 51, 1, 12, 20, 29, 1, 12, 21, 1, 7, 16, 23,
        31, 36, 44, 51, 55, 63, 1, 8, 15, 23, 32, 40, 49, 4, 12, 19, 31, 39,
        45, 13, 28, 41, 55, 71, 1, 25, 52, 77, 103, 127, 154, 1, 17, 27, 43,
        62, 84, 6, 11, 22, 32, 41, 48, 57, 68, 75, 8, 17, 26, 34, 41, 50, 59,
        67, 78, 1, 12, 21, 30, 39, 47, 1, 11, 16, 23, 32, 45, 52, 11, 23, 34,
        48, 61, 74, 1, 19, 40, 1, 14, 23, 33, 6, 15, 21, 29, 1, 12, 20, 30, 1,
        10, 16, 24, 29, 5, 12, 1, 16, 36, 7, 31, 52, 15, 32, 1, 27, 45, 7, 28,
        50, 17, 41, 68, 17, 51, 77, 4, 12, 19, 25, 1, 7, 12, 22, 4, 10, 17, 1,
        6, 12, 6, 1, 9, 5, 1, 10, 1, 6, 1, 8, 1, 13, 27, 16, 43, 9, 35, 11, 40,
        11, 1, 14, 1, 20, 18, 48, 20, 6, 26, 20, 1, 31, 16, 1, 1, 1, 7, 35, 1,
        1, 16, 1, 24, 1, 15, 1, 1, 8, 10, 1, 1, 1, 1
    };

      public static int[] JUZ_PAGE_START = {
        2, 22, 42, 62, 82, 102, 121, 142, 162, 182,
        201, 222, 242, 262, 282, 302, 322, 342, 362, 382,
        402, 422, 442, 462, 482, 502, 522, 542, 562, 582
    };

      public static int[] SURA_NUM_AYAHS = {
        7, 286, 200, 176, 120, 165, 206, 75, 129, 109, 123, 111,
        43, 52, 99, 128, 111, 110, 98, 135, 112, 78, 118, 64, 77,
        227, 93, 88, 69, 60, 34, 30, 73, 54, 45, 83, 182, 88, 75,
        85, 54, 53, 89, 59, 37, 35, 38, 29, 18, 45, 60, 49, 62, 55,
        78, 96, 29, 22, 24, 13, 14, 11, 11, 18, 12, 12, 30, 52, 52,
        44, 28, 28, 20, 56, 40, 31, 50, 40, 46, 42, 29, 19, 36, 25,
        22, 17, 19, 26, 30, 20, 15, 21, 11, 8, 8, 19, 5, 8, 8, 11,
        11, 8, 3, 9, 5, 4, 7, 3, 6, 3, 5, 4, 5, 6
    };

      public static bool[] SURA_IS_MAKKI = {
        true, false, false, false, false, true, true, false, false, true,
        true, true, false, true, true, true, true, true, true, true,
        true, false, true, false, true, true, true, true, true, true,
        true, true, false, true, true, true, true, true, true, true,
        true, true, true, true, true, true, false, false, false, true,
        true, true, true, true, false, true, false, false, false, false,
        false, false, false, false, false, false, true, true, true, true,
        true, true, true, true, true, false, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, false, false, true,
        true, true, true, true, true, true, true, true, true, false,
        true, true, true, true
    };
      public static QuarterHizbEndInfo[] QUARTER_HIZB_INFO_LIST =
      {
        // Hizb 1
        new QuarterHizbEndInfo(2, 25),
        new QuarterHizbEndInfo(2, 43),
        new QuarterHizbEndInfo(2, 59),
        new QuarterHizbEndInfo(2, 74),

        // Hizb 2
        new QuarterHizbEndInfo(2, 91),
        new QuarterHizbEndInfo(2, 105),
        new QuarterHizbEndInfo(2, 123),
        new QuarterHizbEndInfo(2, 141),
        
        // Hizb 3
        new QuarterHizbEndInfo(2 , 157),
        new QuarterHizbEndInfo(2, 176),
        new QuarterHizbEndInfo(2, 188),
        new QuarterHizbEndInfo(2, 202),
        
        // Hizb 4
        new QuarterHizbEndInfo(2, 218),
        new QuarterHizbEndInfo(2, 232),
        new QuarterHizbEndInfo(2, 242),
        new QuarterHizbEndInfo(2, 252),
        
        // Hizb 5
        new QuarterHizbEndInfo(2, 262),
        new QuarterHizbEndInfo(2, 271),
        new QuarterHizbEndInfo(2, 282),
        new QuarterHizbEndInfo(3, 14),
        
        // Hizb 6
        new QuarterHizbEndInfo(3, 32),
        new QuarterHizbEndInfo(3, 51),
        new QuarterHizbEndInfo(3, 74),
        new QuarterHizbEndInfo(3, 92),
        
        // Hizb 7
        new QuarterHizbEndInfo(3, 112),
        new QuarterHizbEndInfo(3, 132),
        new QuarterHizbEndInfo(3, 152),
        new QuarterHizbEndInfo(3, 170),
        
        // Hizb 8
        new QuarterHizbEndInfo(3, 185),
        new QuarterHizbEndInfo(3, 200),
        new QuarterHizbEndInfo(4, 11),
        new QuarterHizbEndInfo(4, 23),
        
        // Hizb 9
        new QuarterHizbEndInfo(4, 35),
        new QuarterHizbEndInfo(4, 57),
        new QuarterHizbEndInfo(4, 73),
        new QuarterHizbEndInfo(4, 87),
        
        // Hizb 10
        new QuarterHizbEndInfo(4, 99),
        new QuarterHizbEndInfo(4, 113),
        new QuarterHizbEndInfo(4, 134),
        new QuarterHizbEndInfo(4, 147),
        
        // Hizb 11
        new QuarterHizbEndInfo(4, 162),
        new QuarterHizbEndInfo(4, 176),
        new QuarterHizbEndInfo(5, 11),
        new QuarterHizbEndInfo(5, 26),
        
        // Hizb 12
        new QuarterHizbEndInfo(5, 40),
        new QuarterHizbEndInfo(5, 50),
        new QuarterHizbEndInfo(5, 66),
        new QuarterHizbEndInfo(5, 81),
        
        // Hizb 13
        new QuarterHizbEndInfo(5, 96),
        new QuarterHizbEndInfo(5, 108),
        new QuarterHizbEndInfo(6, 12),
        new QuarterHizbEndInfo(6, 35),
        
        // Hizb 14
        new QuarterHizbEndInfo(6, 58),
        new QuarterHizbEndInfo(6, 73),
        new QuarterHizbEndInfo(6, 94),
        new QuarterHizbEndInfo(6, 110),
        
        // Hizb 15
        new QuarterHizbEndInfo(6, 126),
        new QuarterHizbEndInfo(6, 140),
        new QuarterHizbEndInfo(6, 150),
        new QuarterHizbEndInfo(6, 165),
        
        // Hizb 16
        new QuarterHizbEndInfo(7, 30),
        new QuarterHizbEndInfo(7, 46),
        new QuarterHizbEndInfo(7, 64),
        new QuarterHizbEndInfo(7, 87),
        
        // Hizb 17
        new QuarterHizbEndInfo(7, 116),
        new QuarterHizbEndInfo(7, 141),
        new QuarterHizbEndInfo(7, 155),
        new QuarterHizbEndInfo(7, 170),
        
        // Hizb 18
        new QuarterHizbEndInfo(7, 188),
        new QuarterHizbEndInfo(7, 206),
        new QuarterHizbEndInfo(8, 21),
        new QuarterHizbEndInfo(8, 40),
        
        // Hizb 19
        new QuarterHizbEndInfo(8, 60),
        new QuarterHizbEndInfo(8, 75),
        new QuarterHizbEndInfo(9, 18),
        new QuarterHizbEndInfo(9, 33),
        
        // Hizb 20
        new QuarterHizbEndInfo(9, 45),
        new QuarterHizbEndInfo(9, 59),
        new QuarterHizbEndInfo(9, 74),
        new QuarterHizbEndInfo(9, 92),
        
        // Hizb 21
        new QuarterHizbEndInfo(9, 110),
        new QuarterHizbEndInfo(9, 121),
        new QuarterHizbEndInfo(10, 10),
        new QuarterHizbEndInfo(10, 25),
        
        // Hizb 22
        new QuarterHizbEndInfo(10, 52),
        new QuarterHizbEndInfo(10, 70),
        new QuarterHizbEndInfo(10, 89),
        new QuarterHizbEndInfo(11, 5),
        
        // Hizb 23
        new QuarterHizbEndInfo(11, 23),
        new QuarterHizbEndInfo(11, 40),
        new QuarterHizbEndInfo(11, 60),
        new QuarterHizbEndInfo(11, 83),
        
        // Hizb 24
        new QuarterHizbEndInfo(11, 107),
        new QuarterHizbEndInfo(12, 6),
        new QuarterHizbEndInfo(12, 29),
        new QuarterHizbEndInfo(12, 52),
        
        // Hizb 25
        new QuarterHizbEndInfo(12, 76),
        new QuarterHizbEndInfo(12, 100),
        new QuarterHizbEndInfo(13, 4),
        new QuarterHizbEndInfo(13, 18),
        
        // Hizb 26
        new QuarterHizbEndInfo(13, 34),
        new QuarterHizbEndInfo(14, 9),
        new QuarterHizbEndInfo(14, 27),
        new QuarterHizbEndInfo(14, 52),
        
        // Hizb 27
        new QuarterHizbEndInfo(15, 48),
        new QuarterHizbEndInfo(15, 99),
        new QuarterHizbEndInfo(16, 29),
        new QuarterHizbEndInfo(16, 50),
        
        // Hizb 28
        new QuarterHizbEndInfo(16, 74),
        new QuarterHizbEndInfo(16, 89),
        new QuarterHizbEndInfo(16, 110),
        new QuarterHizbEndInfo(16, 128),
        
        // Hizb 29
        new QuarterHizbEndInfo(17, 22),
        new QuarterHizbEndInfo(17, 49),
        new QuarterHizbEndInfo(17, 69),
        new QuarterHizbEndInfo(17, 98),
        
        // Hizb 30
        new QuarterHizbEndInfo(18, 16),
        new QuarterHizbEndInfo(18, 31),
        new QuarterHizbEndInfo(18, 50),
        new QuarterHizbEndInfo(18, 74),
        
        // Hizb 31
        new QuarterHizbEndInfo(18, 98),
        new QuarterHizbEndInfo(19, 21),
        new QuarterHizbEndInfo(19, 58),
        new QuarterHizbEndInfo(19, 98),
        
        // Hizb 32
        new QuarterHizbEndInfo(20, 54),
        new QuarterHizbEndInfo(20, 82),
        new QuarterHizbEndInfo(20, 110),
        new QuarterHizbEndInfo(20, 135),
        
        // Hizb 33
        new QuarterHizbEndInfo(21, 28),
        new QuarterHizbEndInfo(21, 50),
        new QuarterHizbEndInfo(21, 82),
        new QuarterHizbEndInfo(21, 112),
        
        // Hizb 34
        new QuarterHizbEndInfo(22, 18),
        new QuarterHizbEndInfo(22, 37),
        new QuarterHizbEndInfo(22, 59),
        new QuarterHizbEndInfo(22, 78),
        
        // Hizb 35
        new QuarterHizbEndInfo(23, 35),
        new QuarterHizbEndInfo(23, 74),
        new QuarterHizbEndInfo(23, 118),
        new QuarterHizbEndInfo(24, 20),
        
        // Hizb 36
        new QuarterHizbEndInfo(24, 34),
        new QuarterHizbEndInfo(24, 52),
        new QuarterHizbEndInfo(24, 64),
        new QuarterHizbEndInfo(25, 20),
        
        // Hizb 37
        new QuarterHizbEndInfo(25, 52),
        new QuarterHizbEndInfo(25, 77),
        new QuarterHizbEndInfo(26, 51),
        new QuarterHizbEndInfo(26, 110),
        
        // Hizb 38
        new QuarterHizbEndInfo(26, 180),
        new QuarterHizbEndInfo(26, 227),
        new QuarterHizbEndInfo(27, 26),
        new QuarterHizbEndInfo(27, 55),
        
        // Hizb 39
        new QuarterHizbEndInfo(27, 81),
        new QuarterHizbEndInfo(28, 11),
        new QuarterHizbEndInfo(28, 28),
        new QuarterHizbEndInfo(28, 50),
        
        // Hizb 40
        new QuarterHizbEndInfo(28, 75),
        new QuarterHizbEndInfo(28, 88),
        new QuarterHizbEndInfo(29, 25),
        new QuarterHizbEndInfo(29, 45),
        
        // Hizb 41
        new QuarterHizbEndInfo(29, 69),
        new QuarterHizbEndInfo(30, 30),
        new QuarterHizbEndInfo(30, 53),
        new QuarterHizbEndInfo(31, 21),
        
        // Hizb 42
        new QuarterHizbEndInfo(32, 10),
        new QuarterHizbEndInfo(32, 30),
        new QuarterHizbEndInfo(33, 17),
        new QuarterHizbEndInfo(33, 30),
        
        // Hizb 43
        new QuarterHizbEndInfo(33, 50),
        new QuarterHizbEndInfo(33, 59),
        new QuarterHizbEndInfo(34, 9),
        new QuarterHizbEndInfo(34, 23),
        
        // Hizb 44
        new QuarterHizbEndInfo(34, 45),
        new QuarterHizbEndInfo(35, 14),
        new QuarterHizbEndInfo(35, 40),
        new QuarterHizbEndInfo(36, 27),
        
        // Hizb 45
        new QuarterHizbEndInfo(36, 59),
        new QuarterHizbEndInfo(37, 21),
        new QuarterHizbEndInfo(37, 82),
        new QuarterHizbEndInfo(37, 144),
        
        // Hizb 46
        new QuarterHizbEndInfo(38, 20),
        new QuarterHizbEndInfo(38, 51),
        new QuarterHizbEndInfo(39, 7),
        new QuarterHizbEndInfo(39, 31),
        
        // Hizb 47
        new QuarterHizbEndInfo(39, 52),
        new QuarterHizbEndInfo(39, 75),
        new QuarterHizbEndInfo(40, 20),
        new QuarterHizbEndInfo(40, 40),
        
        // Hizb 48
        new QuarterHizbEndInfo(40, 65),
        new QuarterHizbEndInfo(41, 8),
        new QuarterHizbEndInfo(41, 24),
        new QuarterHizbEndInfo(41, 46),
        
        // Hizb 49
        new QuarterHizbEndInfo(42, 12),
        new QuarterHizbEndInfo(42, 26),
        new QuarterHizbEndInfo(42, 50),
        new QuarterHizbEndInfo(43, 23),
        
        // Hizb 50
        new QuarterHizbEndInfo(43, 56),
        new QuarterHizbEndInfo(44, 16),
        new QuarterHizbEndInfo(45, 11),
        new QuarterHizbEndInfo(45, 37),
        
        // Hizb 51
        new QuarterHizbEndInfo(46, 20),
        new QuarterHizbEndInfo(47, 9),
        new QuarterHizbEndInfo(47, 32),
        new QuarterHizbEndInfo(48, 17),
        
        // Hizb 52
        new QuarterHizbEndInfo(48, 29),
        new QuarterHizbEndInfo(49, 13),
        new QuarterHizbEndInfo(50, 26),
        new QuarterHizbEndInfo(51, 30),
        
        // Hizb 53
        new QuarterHizbEndInfo(52, 23),
        new QuarterHizbEndInfo(53, 25),
        new QuarterHizbEndInfo(54, 8),
        new QuarterHizbEndInfo(54, 55),
        
        // Hizb 54
        new QuarterHizbEndInfo(55, 78),
        new QuarterHizbEndInfo(56, 74),
        new QuarterHizbEndInfo(57, 15),
        new QuarterHizbEndInfo(57, 29),
        
        // Hizb 55
        new QuarterHizbEndInfo(58, 13),
        new QuarterHizbEndInfo(59, 10),
        new QuarterHizbEndInfo(60, 6),
        new QuarterHizbEndInfo(61, 14),
        
        // Hizb 56
        new QuarterHizbEndInfo(63, 3),
        new QuarterHizbEndInfo(64, 18),
        new QuarterHizbEndInfo(65, 12),
        new QuarterHizbEndInfo(66, 12),
        
        // Hizb 57
        new QuarterHizbEndInfo(67, 30),
        new QuarterHizbEndInfo(68, 52),
        new QuarterHizbEndInfo(70, 18),
        new QuarterHizbEndInfo(71, 28),
        
        // Hizb 58
        new QuarterHizbEndInfo(73, 19),
        new QuarterHizbEndInfo(74, 56),
        new QuarterHizbEndInfo(76, 18),
        new QuarterHizbEndInfo(77, 50),
        
        // Hizb 59
        new QuarterHizbEndInfo(79, 46),
        new QuarterHizbEndInfo(81, 19),
        new QuarterHizbEndInfo(83, 36),
        new QuarterHizbEndInfo(86, 17),
        
        // Hizb 60
        new QuarterHizbEndInfo(89, 30),
        new QuarterHizbEndInfo(93, 11),
        new QuarterHizbEndInfo(100, 8),
        new QuarterHizbEndInfo(114, 6),
    };

      public static int GetPageNumberFromSuraAya(int suraNumber, int ayaNumber)
      {
         int targetPage = SURA_PAGE_START[suraNumber - 1];
         int suraStartPage;
         int suraEndPage;
         int currentPage, currentPageAyaStart, currentPageAyaEnd;

         suraStartPage = SURA_PAGE_START[suraNumber - 1];
         if (suraStartPage == PAGE_SURA_START.Length)
         {
            targetPage = PAGE_SURA_START.Length;
         }
         else
         {
            suraEndPage = suraStartPage;
            while (PAGE_SURA_START[suraEndPage - 1] <= suraNumber)
               suraEndPage++;

            suraEndPage--;

            //  showMsgDialog(QString::number(suraStartPage), QString::number(suraEndPage));

            for (currentPage = suraStartPage; currentPage <= suraEndPage; currentPage++)
            {
               if (PAGE_SURA_START[currentPage - 1] < suraNumber)
               {
                  currentPageAyaStart = 1;
               }
               else
               {
                  currentPageAyaStart = PAGE_AYAH_START[currentPage - 1];
               }

               if (currentPage == suraEndPage)
               {
                  currentPageAyaEnd = SURA_NUM_AYAHS[suraNumber - 1];
               }
               else
               {
                  currentPageAyaEnd = PAGE_AYAH_START[currentPage - 1 + 1] - 1;
               }

               if (ayaNumber >= currentPageAyaStart && ayaNumber <= currentPageAyaEnd)
               {
                  targetPage = currentPage;
                  break;
               }
            }
         }

         return targetPage;
      }

      public static AyaRange GetAyaRangeFromGeneralIndex(int index)
      {
         AyaRange result = GetAyaRangeFromPageIndex(index);
        
         return result;
      }

      static AyaRange GetAyaRangeFromHizbJuzIndex(int hizbJuzIndex, CategorizeType categorizeType)
      {
         AyaRange result = new AyaRange();
         int QHizbMultiplier = 1;
         int indexToUse;

         if (categorizeType == CategorizeType.ByQuarterHizb)
         {
            QHizbMultiplier = 1;
         }
         else if (categorizeType == CategorizeType.ByHalfHizb)
         {
            QHizbMultiplier = 2;
         }
         else if (categorizeType == CategorizeType.ByHizb)
         {
            QHizbMultiplier = 4;
         }
         else if (categorizeType == CategorizeType.ByJuz)
         {
            QHizbMultiplier = 8;
         }

         indexToUse = hizbJuzIndex * QHizbMultiplier;

         if (indexToUse == 0)
         {
            result.startAyaInfo.suraNumber = 1;
            result.startAyaInfo.ayaNumber = 1;
         }
         else
         {
            if (QUARTER_HIZB_INFO_LIST[indexToUse - 1].ayaNumber <
               SURA_NUM_AYAHS[QUARTER_HIZB_INFO_LIST[indexToUse - 1].suraNumber - 1])
            {
               result.startAyaInfo.suraNumber = QUARTER_HIZB_INFO_LIST[indexToUse - 1].suraNumber;
               result.startAyaInfo.ayaNumber = QUARTER_HIZB_INFO_LIST[indexToUse - 1].ayaNumber + 1;
            }
            else
            {
               result.startAyaInfo.suraNumber = QUARTER_HIZB_INFO_LIST[indexToUse - 1].suraNumber + 1;
               result.startAyaInfo.ayaNumber = 1;
            }
         }
         result.endAyaInfo.suraNumber = QUARTER_HIZB_INFO_LIST[indexToUse + QHizbMultiplier - 1].suraNumber;
         result.endAyaInfo.ayaNumber = QUARTER_HIZB_INFO_LIST[indexToUse + QHizbMultiplier - 1].ayaNumber;
         return result;
      }

      static List<AyaRange> GetAyaRangesForSuraByPage(int suraNum)
      {
         List<AyaRange> result = new List<AyaRange>();

         int firstPage = SURA_PAGE_START[suraNum - 1];
         int currentPage = firstPage;
         int lastPage = firstPage;
         while (lastPage <= 604 && PAGE_SURA_START[lastPage - 1] <= suraNum)
         {
            lastPage++;
         }
         lastPage--;

         for (currentPage = firstPage; currentPage <= lastPage; currentPage++)
         {
            AyaRange currentPageRange = new AyaRange();

            currentPageRange.startAyaInfo.suraNumber = currentPageRange.endAyaInfo.suraNumber = suraNum;

            if (currentPage == firstPage)
            {
               currentPageRange.startAyaInfo.ayaNumber = 1;
            }
            else
            {
               currentPageRange.startAyaInfo.ayaNumber = PAGE_AYAH_START[currentPage - 1];
            }

            if (currentPage == lastPage)
            {
               currentPageRange.endAyaInfo.ayaNumber = SURA_NUM_AYAHS[suraNum - 1];
            }
            else
            {
               currentPageRange.endAyaInfo.ayaNumber = PAGE_AYAH_START[currentPage] - 1;
            }

            result.Add(currentPageRange);
         }


         return result;
      }

      static AyaRange GetAyaRangeFromPageIndex(int pageIndex)
      {
         AyaRange result = new AyaRange();
         result.startAyaInfo.suraNumber = PAGE_SURA_START[pageIndex];
         result.startAyaInfo.ayaNumber = PAGE_AYAH_START[pageIndex];
         if (pageIndex == PAGE_SURA_START.Length - 1)
         {
            result.endAyaInfo.suraNumber = 114;
            result.endAyaInfo.ayaNumber = SURA_NUM_AYAHS[113];
         }
         else
         {
            int nextPageStartSuraNumber = PAGE_SURA_START[pageIndex + 1];
            int nextPageStartAyaNumber = PAGE_AYAH_START[pageIndex + 1];
            if (nextPageStartSuraNumber == result.startAyaInfo.suraNumber)
            {
               result.endAyaInfo.suraNumber = result.startAyaInfo.suraNumber;
               result.endAyaInfo.ayaNumber = nextPageStartAyaNumber - 1;
            }
            else
            {
               if (nextPageStartAyaNumber == 1)
               {
                  result.endAyaInfo.suraNumber = nextPageStartSuraNumber - 1;
                  result.endAyaInfo.ayaNumber = SURA_NUM_AYAHS[(nextPageStartSuraNumber - 1) - 1];
               }
               else
               {
                  result.endAyaInfo.suraNumber = nextPageStartSuraNumber;
                  result.endAyaInfo.ayaNumber = nextPageStartAyaNumber - 1;
               }
            }
         }
         return result;
      }

      public static AyaRange GetAyaRangeFromPageRange(int startPageIndex, int endPageIndex)
      {
         AyaRange startPageRange, endPageRange, result;

         startPageRange = GetAyaRangeFromPageIndex(startPageIndex);
         endPageRange = GetAyaRangeFromPageIndex(endPageIndex);

         result = new AyaRange();

         result.startAyaInfo = startPageRange.startAyaInfo;
         result.endAyaInfo = endPageRange.endAyaInfo;

         return result;
      }

      public static AyaRange GetPageRangeForAyaInfo(AyaInfo info)
      {
         int pageNumber = GetPageNumberFromSuraAya(info.suraNumber, info.ayaNumber);

         return GetAyaRangeFromPageIndex(pageNumber - 1);
      }
   }
}

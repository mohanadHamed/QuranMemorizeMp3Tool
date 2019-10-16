using System;
using System.IO;

namespace QuranMemorizeMp3Tool
{

   public static class RecitersUtility
   {

      public static string[] baseRecitingURLs = {
                            "http://dyaasoft.com/strg/quran_files/",
                            "http://www.everyayah.com/data/"
      };

      public static Reciter[] allReciters = new Reciter[]
      {
      new Reciter(1, "Saood_ash-Shuraym_128kbps", "Saud AL Shrem", "سعود الشريم"),
      new Reciter(1, "Abdul_Basit_Murattal_192kbps", "Abdul Basit", "عبد الباسط عبد الصمد"),
      new Reciter(1, "Abu_Bakr_Ash-Shaatree_128kbps", "Abu Bakr Ash-Shatree", "أبو بكر الشاطري"),
      new Reciter(1, "Ghamadi_40kbps", "Sa'd AL Ghamdi", "سعد الغامدي"),
      new Reciter(1, "Husary_128kbps", "Mahmood AL Husary", "محمود خليل الحصري"),
      new Reciter(1, "MaherAlMuaiqly128kbps", "Maher Muaiqly", "ماهر المعيقلي" ),
      new Reciter(1, "Ahmed_ibn_Ali_al-Ajamy_128kbps_ketaballah.net", "Ahmad Al Ajmi", "أحمد العجمي"),
      new Reciter(1, "Ali_Jaber_64kbps", "Ali Jaber", "علي جابر"),
      new Reciter(1, "Minshawy_Murattal_128kbps", "AL Menshawi", "محمد صديق المنشاوي"),
      new Reciter(1, "Nasser_Alqatami_128kbps", "Naser Qtami", "ناصر القطامي"),
		//new Reciter(1, "sayegh", "Tawfiq AL Sayegh", "توفيق الصائغ"),
		new Reciter(1, "Hudhaify_128kbps", "Ali Hudhaifi", "علي عبدالرحمن الحذيفي"),
      new Reciter(1, "Fares_Abbad_64kbps", "Faris Abbad", "فارس عباد"),
		//new Reciter(1, "mhr_shakhasheero", "Maher Shakhasheero", "ماهر شخاشيرو"),
		new Reciter(1, "Yasser_Ad-Dussary_128kbps", "Yaser AL Dussary", "ياسر الدوسري"),
      new Reciter(1, "Abdullah_Basfar_192kbps", "Abdullah Basfar", "عبدالله بصفر"),
      new Reciter(1, "Abdullah_Matroud_128kbps", "Abdullah Matrood", "عبدالله مطرود"),
      new Reciter(1, "Ahmed_Neana_128kbps", "Ahmad Neana", "أحمد نعينع"),
      new Reciter(1, "Akram_AlAlaqimy_128kbps", "Akram Alaqmi", "أكرم العلاقمي"),
      new Reciter(1, "Ali_Hajjaj_AlSuesy_128kbps", "Ali Hajjaj Swesi", "علي حجاج السويسي"),
      new Reciter(1, "Hani_Rifai_192kbps", "Hani Rifai", "هاني الرفاعي"),
      new Reciter(1, "Ibrahim_Akhdar_32kbps", "Ibrahim Al Akhdar", "ابراهيم الأخضر"),
      new Reciter(1, "Karim_Mansoori_40kbps", "Kareem Mansori", "كريم منصوري"),
      new Reciter(1, "Khaalid_Abdullaah_al-Qahtaanee_192kbps", "Khalid AL Qahtani", "خالد القحطاني"),
      new Reciter(1, "Mohammad_al_Tablaway_128kbps", "AL Tablawi", "محمد الطبلاوي"),
      new Reciter(1, "Muhammad_AbdulKareem_128kbps", "Mohammad AbdulKareem", "محمد عبد الكريم"),
      new Reciter(1, "Muhammad_Ayyoub_128kbps", "Mohammad Ayyoub", "محمد أيوب"),
      new Reciter(1, "Muhammad_Jibreel_128kbps", "Mohammad Jibreel", "محمد جبريل"),
      new Reciter(1, "Muhsin_Al_Qasim_192kbps", "Abdul Muhsin AL Qasem", "عبد المحسن القاسم"),
      new Reciter(1, "Sahl_Yassin_128kbps", "Sahl Yaseen", "سهل ياسين"),
      new Reciter(1, "Salaah_AbdulRahman_Bukhatir_128kbps", "Salah Bukhatir", "صلاح بوخاطر"),
      new Reciter(1, "Salah_Al_Budair_128kbps", "Salah AL Bdair", "صلاح البدير"),
      new Reciter(1, "Yaser_Salamah_128kbps", "Yaser Salamah", "ياسر سلامة"),
      new Reciter(1, "khalefa_al_tunaiji_64kbps", "Khalifa AL Tunaiji", "خليفة الطنيجي"),
      new Reciter(1, "mahmoud_ali_al_banna_32kbps", "Mahmood Ali AL Banna", "محمود علي البنا"),
      new Reciter(1, "aziz_alili_128kbps", "Aziz Alili", "عزيز عليلي"),
      new Reciter(1, "Abdullaah_3awwaad_Al-Juhaynee_128kbps", "Abddullah Awwad AL Juhani", "عبدالله عواد الجهني"),
		//new Reciter(1, "khld_mhanna", "Khalid Mhanna", "خالد المهنا"),
		//new Reciter(1, "mohd_rashad", "Mohammad Rashad AL Shareef", "محمد رشاد الشريف"),
		new Reciter(1, "Mustafa_Ismail_48kbps", "Mustafa Ismail", "مصطفى اسماعيل"),
		//new Reciter(1, "salah_alhashem", "Salah AL HAshem", "صلاح الهاشم"),
		//new Reciter(1, "shahriar_brhiz_kar", "Shahriar Brhiz Kar", "شهريار برهيز كار"),
		new Reciter(1, "Abdul_Basit_Mujawwad_128kbps", "Abdulbasit-Mujawwad", "عبد الباسط-مجود"),
      new Reciter(1, "Husary_128kbps_Mujawwad", "Mahmoud  Al Husary - Mujawwad", "محمود الحصري-مجود"),
      new Reciter(1, "Minshawy_Mujawwad_192kbps", "AL Menshawi-Mujawad", "المنشاوي-مجود"),
		//new Reciter(1, "en_basfar_mujawwad", "ENG-Abdullah Basfar-Mujawwad", "انجليزي-عبدالله بصفر-مجود"),
	//	new Reciter(1, "urdo_farahat_hashmi", "Urdo-Farahat Hashmi", "أردو-فرحات الهاشمي"),
      new Reciter(1, "warsh/warsh_ibrahim_aldosary_128kbps", "Warsh-Ibrahim AL Dusari", "ورش:ابراهيم الدوسري"),
      new Reciter(1, "warsh/warsh_yassin_al_jazaery_64kbps", "Warsh-Yassin AL Jazaery", "ورش:ياسين الجزائري"),
      new Reciter(1, "warsh/warsh_Abdul_Basit_128kbps", "Warsh:Abdulbasit", "ورش:عبدالباسط")
         //new Reciter(1, "warsh_husari", "Warsh:AL Hosary", "ورش:الحصري"),
         //new Reciter(1, "tarabulsi_qalon", "Qaloon-Ahmad AL Tarabulsi", "قالون:أحمد الطرابلسي"),
         //new Reciter(1, "qalon_hudaifi", "Qaloon: AL Hudhaifi", "قالون:علي الحذيفي"),
         //new Reciter(1, "qalon_husary", "Qaloon: AL Husary", "قالون:الحصري"),
         //new Reciter(1, "dori_mftah_saltani", "Dori:Mftah Saltani", "الدوري:مفتاح السلطني"),
         //new Reciter(1, "shuba_khamri", "Shuba: Fuad AL Khamri", "شعبة:فؤاد الخامري")
      };

      public static string GetURLForAyah(Reciter reciter, int suraNumber, int ayahNumber)
      {
         return baseRecitingURLs[reciter.urlIndex] + reciter.id + "/" + QuranMp3JoinUtil.FileNameForAya(AyaInfo.Create(suraNumber, ayahNumber));
      }
   }

   public struct Reciter
   {
      public string id;
      public string nameEn;
      public string nameAr;
      public int urlIndex;

      public string BlankResourceName => /*"QuranMemorizeMp3Tool.resources." + */id.Replace("/", "_") + ".mp3";

      public Reciter(int urlIndex, string id, string nameEn, string nameAr)
      {
         this.id = id;
         this.nameEn = nameEn;
         this.nameAr = nameAr;
         this.urlIndex = urlIndex;
      }
   }

}

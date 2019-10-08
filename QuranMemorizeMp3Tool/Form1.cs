using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranMemorizeMp3Tool
{
   public partial class Form1 : Form
   {
      Dictionary<CategorizeType, int> maxIndex = new Dictionary<CategorizeType, int> 
      { { CategorizeType.BySura, 113 },
      { CategorizeType.ByPage, 603 },
      { CategorizeType.ByJuz, 29 },
      { CategorizeType.ByHizb, 59 },
      { CategorizeType.ByHalfHizb, 119 },
      { CategorizeType.ByQuarterHizb, 239 }, };

      public Form1()
      {
         InitializeComponent();
      }

      private void srcBrowseButton_Click(object sender, EventArgs e)
      {
         using (var fbd = new FolderBrowserDialog())
         {
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
               srcTextBox.Text = fbd.SelectedPath;
            }
         }
      }

      private void destBrowseButton_Click(object sender, EventArgs e)
      {
         using (var fbd = new FolderBrowserDialog())
         {
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
               destTextBox.Text = fbd.SelectedPath;
            }
         }
      }

      private void button3_Click(object sender, EventArgs e)
      {
         var categorizeType = (CategorizeType)typeComboBox.SelectedIndex;
         var maxGeneralIndex = maxIndex[categorizeType];

         var ayaRange = QuranArrayHelper.GetAyaRangeFromGeneralIndex(maxGeneralIndex, categorizeType);
         var files = GetAyaFileList(ayaRange);

      }

      List<string> GetAyaFileList(AyaRange ayaRange)
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

            if(currentAya < QuranArrayHelper.SURA_NUM_AYAHS[currentSura])
            {
               currentAya++;
            }
            else
            {
               currentSura++;
               currentAya = 1;
            }

         } while (weight(currentSura, currentAya) <= weight(ayaRange.endAyaInfo.suraNumber, ayaRange.endAyaInfo.ayaNumber));
         
         return result;
      }

      int weight(int sura, int aya)
      {
         return sura * 1000 + aya;
      }

      string ThreeDigit(string s)
      {
         string result = s;
         while(result.Length < 3)
         {
            result = "0" + result;
         }

         return result;
      }
   }
}

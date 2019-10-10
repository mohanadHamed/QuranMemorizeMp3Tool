using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranMemorizeMp3Tool
{
   public enum DynamicGap
   {
      CurrentAyaDurationHalf,
      CurrentAyaDurationOne,
      CurrentAyaDuratioOneAndHalf,
      CurrentAyaDurationTwo,
      NextAyaDurationHalf,
      NextAyaDurationOne,
      NextAyaDuratioOneAndHalf,
      NextAyaDurationTwo
   }
   public partial class Form1 : Form
   {

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
         var juz = juzComboBox.SelectedIndex + 1;
         var dynamicGap = (DynamicGap)dynamicGapComboBox.SelectedIndex;

         QuranMp3JoinUtil joinUtil = new QuranMp3JoinUtil(srcTextBox.Text, destTextBox.Text);
         joinUtil.GenerateJoinedMp3(juz, dynamicGap, fixedGapNumericUpDown.Value, progressBar);
      }
   }
}

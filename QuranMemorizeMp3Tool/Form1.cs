using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuranMemorizeMp3Tool
{
   public partial class Form1 : Form
   {
      QuranMp3JoinUtil joinUtil;

      public Form1()
      {
         InitializeComponent();
         InitializeReciterComboBox();
      }

      private void InitializeReciterComboBox()
      {
         List<string> reciterNames = new List<string>();

         foreach(var reciter in RecitersUtility.allReciters)
         {
            reciterNames.Add(reciter.nameEn);
         }

         reciterComboBox.Items.AddRange(reciterNames.ToArray());
         reciterComboBox.SelectedIndex = 0;
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

      private void generateButton_Click(object sender, EventArgs e)
      {
         if(string.IsNullOrEmpty(destTextBox.Text))
         {
            MessageBox.Show("Please select output directory");
            return;
         }

         try
         {
            var juz = juzComboBox.SelectedIndex + 1;
            var dynamicGap = (DynamicGap)dynamicGapComboBox.SelectedIndex;

            generateButton.Enabled = false;
            cancelButton.Enabled = true;
            joinUtil = new QuranMp3JoinUtil(RecitersUtility.allReciters[reciterComboBox.SelectedIndex], destTextBox.Text, downloadProgressBar, totalProgressBar);
            joinUtil.GenerateJoinedMp3(juz, dynamicGap, fixedGapNumericUpDown.Value);

            while (joinUtil.Processing)
            {
               Application.DoEvents();
            }

            MessageBox.Show("Done");
            Reset();
         }
         catch(Exception ex)
         {
            MessageBox.Show("Error" + ex.Message);
            Reset();
         }
      }

      private void cancelButton_Click(object sender, EventArgs e)
      {
         Reset();
      }

      private void Reset()
      {
         if (joinUtil != null)
         {
            joinUtil.Done();
         }

         cancelButton.Enabled = false;
         generateButton.Enabled = true;
      }
   }
}

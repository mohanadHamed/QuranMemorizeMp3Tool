namespace QuranMemorizeMp3Tool
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.selectReciterLabel = new System.Windows.Forms.Label();
         this.destBrowseButton = new System.Windows.Forms.Button();
         this.destTextBox = new System.Windows.Forms.TextBox();
         this.outputDirLabel = new System.Windows.Forms.Label();
         this.selectJuzLabel = new System.Windows.Forms.Label();
         this.juzComboBox = new System.Windows.Forms.ComboBox();
         this.dynamicGapLabel = new System.Windows.Forms.Label();
         this.dynamicGapComboBox = new System.Windows.Forms.ComboBox();
         this.fixedGapNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.fixedGapLabel = new System.Windows.Forms.Label();
         this.secondsLabel = new System.Windows.Forms.Label();
         this.totalProgressBar = new System.Windows.Forms.ProgressBar();
         this.generateButton = new System.Windows.Forms.Button();
         this.reciterComboBox = new System.Windows.Forms.ComboBox();
         this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
         this.downloadProgressLabel = new System.Windows.Forms.Label();
         this.totalProgressLabel = new System.Windows.Forms.Label();
         this.cancelButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // selectReciterLabel
         // 
         this.selectReciterLabel.AutoSize = true;
         this.selectReciterLabel.Location = new System.Drawing.Point(13, 31);
         this.selectReciterLabel.Name = "selectReciterLabel";
         this.selectReciterLabel.Size = new System.Drawing.Size(74, 13);
         this.selectReciterLabel.TabIndex = 0;
         this.selectReciterLabel.Text = "Select Reciter";
         // 
         // destBrowseButton
         // 
         this.destBrowseButton.Location = new System.Drawing.Point(608, 52);
         this.destBrowseButton.Name = "destBrowseButton";
         this.destBrowseButton.Size = new System.Drawing.Size(75, 23);
         this.destBrowseButton.TabIndex = 5;
         this.destBrowseButton.Text = "Browse";
         this.destBrowseButton.UseVisualStyleBackColor = true;
         this.destBrowseButton.Click += new System.EventHandler(this.destBrowseButton_Click);
         // 
         // destTextBox
         // 
         this.destTextBox.Location = new System.Drawing.Point(188, 54);
         this.destTextBox.Name = "destTextBox";
         this.destTextBox.Size = new System.Drawing.Size(390, 20);
         this.destTextBox.TabIndex = 4;
         // 
         // outputDirLabel
         // 
         this.outputDirLabel.AutoSize = true;
         this.outputDirLabel.Location = new System.Drawing.Point(13, 57);
         this.outputDirLabel.Name = "outputDirLabel";
         this.outputDirLabel.Size = new System.Drawing.Size(84, 13);
         this.outputDirLabel.TabIndex = 3;
         this.outputDirLabel.Text = "Output Directory";
         // 
         // selectJuzLabel
         // 
         this.selectJuzLabel.AutoSize = true;
         this.selectJuzLabel.Location = new System.Drawing.Point(13, 95);
         this.selectJuzLabel.Name = "selectJuzLabel";
         this.selectJuzLabel.Size = new System.Drawing.Size(56, 13);
         this.selectJuzLabel.TabIndex = 6;
         this.selectJuzLabel.Text = "Select Juz";
         // 
         // juzComboBox
         // 
         this.juzComboBox.FormattingEnabled = true;
         this.juzComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
         this.juzComboBox.Location = new System.Drawing.Point(188, 92);
         this.juzComboBox.Name = "juzComboBox";
         this.juzComboBox.Size = new System.Drawing.Size(189, 21);
         this.juzComboBox.TabIndex = 7;
         this.juzComboBox.Text = "1";
         // 
         // dynamicGapLabel
         // 
         this.dynamicGapLabel.AutoSize = true;
         this.dynamicGapLabel.Location = new System.Drawing.Point(13, 134);
         this.dynamicGapLabel.Name = "dynamicGapLabel";
         this.dynamicGapLabel.Size = new System.Drawing.Size(171, 13);
         this.dynamicGapLabel.TabIndex = 8;
         this.dynamicGapLabel.Text = "Dynamic Gap Time After Each Aya";
         // 
         // dynamicGapComboBox
         // 
         this.dynamicGapComboBox.FormattingEnabled = true;
         this.dynamicGapComboBox.Items.AddRange(new object[] {
            "No Gap",
            "20% of Aya Duration",
            "40% of Aya Duration",
            "60% of Aya Duration",
            "80% of Aya Duration",
            "Same Aya Duration (100%)",
            "120% of Aya Duration",
            "140% of Aya Duration",
            "160% of Aya Duration",
            "180% of Aya Duration",
            "200% of Aya Duration"});
         this.dynamicGapComboBox.Location = new System.Drawing.Point(188, 131);
         this.dynamicGapComboBox.Name = "dynamicGapComboBox";
         this.dynamicGapComboBox.Size = new System.Drawing.Size(256, 21);
         this.dynamicGapComboBox.TabIndex = 9;
         this.dynamicGapComboBox.Text = "Same Aya Duration (100%)";
         // 
         // fixedGapNumericUpDown
         // 
         this.fixedGapNumericUpDown.Location = new System.Drawing.Point(188, 171);
         this.fixedGapNumericUpDown.Name = "fixedGapNumericUpDown";
         this.fixedGapNumericUpDown.Size = new System.Drawing.Size(63, 20);
         this.fixedGapNumericUpDown.TabIndex = 10;
         // 
         // fixedGapLabel
         // 
         this.fixedGapLabel.AutoSize = true;
         this.fixedGapLabel.Location = new System.Drawing.Point(12, 173);
         this.fixedGapLabel.Name = "fixedGapLabel";
         this.fixedGapLabel.Size = new System.Drawing.Size(108, 13);
         this.fixedGapLabel.TabIndex = 11;
         this.fixedGapLabel.Text = "Extra Fixed Time Gap";
         // 
         // secondsLabel
         // 
         this.secondsLabel.AutoSize = true;
         this.secondsLabel.Location = new System.Drawing.Point(257, 173);
         this.secondsLabel.Name = "secondsLabel";
         this.secondsLabel.Size = new System.Drawing.Size(49, 13);
         this.secondsLabel.TabIndex = 12;
         this.secondsLabel.Text = "Seconds";
         // 
         // totalProgressBar
         // 
         this.totalProgressBar.Location = new System.Drawing.Point(12, 403);
         this.totalProgressBar.Name = "totalProgressBar";
         this.totalProgressBar.Size = new System.Drawing.Size(645, 23);
         this.totalProgressBar.TabIndex = 13;
         // 
         // generateButton
         // 
         this.generateButton.Location = new System.Drawing.Point(149, 247);
         this.generateButton.Name = "generateButton";
         this.generateButton.Size = new System.Drawing.Size(148, 47);
         this.generateButton.TabIndex = 14;
         this.generateButton.Text = "Generate Daily Plan Files";
         this.generateButton.UseVisualStyleBackColor = true;
         this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
         // 
         // reciterComboBox
         // 
         this.reciterComboBox.FormattingEnabled = true;
         this.reciterComboBox.Location = new System.Drawing.Point(188, 22);
         this.reciterComboBox.Name = "reciterComboBox";
         this.reciterComboBox.Size = new System.Drawing.Size(339, 21);
         this.reciterComboBox.TabIndex = 15;
         // 
         // downloadProgressBar
         // 
         this.downloadProgressBar.Location = new System.Drawing.Point(12, 340);
         this.downloadProgressBar.Name = "downloadProgressBar";
         this.downloadProgressBar.Size = new System.Drawing.Size(645, 23);
         this.downloadProgressBar.TabIndex = 16;
         // 
         // downloadProgressLabel
         // 
         this.downloadProgressLabel.AutoSize = true;
         this.downloadProgressLabel.Location = new System.Drawing.Point(9, 315);
         this.downloadProgressLabel.Name = "downloadProgressLabel";
         this.downloadProgressLabel.Size = new System.Drawing.Size(99, 13);
         this.downloadProgressLabel.TabIndex = 17;
         this.downloadProgressLabel.Text = "Download Progress";
         // 
         // totalProgressLabel
         // 
         this.totalProgressLabel.AutoSize = true;
         this.totalProgressLabel.Location = new System.Drawing.Point(9, 378);
         this.totalProgressLabel.Name = "totalProgressLabel";
         this.totalProgressLabel.Size = new System.Drawing.Size(75, 13);
         this.totalProgressLabel.TabIndex = 18;
         this.totalProgressLabel.Text = "Total Progress";
         // 
         // cancelButton
         // 
         this.cancelButton.Enabled = false;
         this.cancelButton.Location = new System.Drawing.Point(326, 247);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(148, 47);
         this.cancelButton.TabIndex = 19;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(705, 451);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.totalProgressLabel);
         this.Controls.Add(this.downloadProgressLabel);
         this.Controls.Add(this.downloadProgressBar);
         this.Controls.Add(this.reciterComboBox);
         this.Controls.Add(this.generateButton);
         this.Controls.Add(this.totalProgressBar);
         this.Controls.Add(this.secondsLabel);
         this.Controls.Add(this.fixedGapLabel);
         this.Controls.Add(this.fixedGapNumericUpDown);
         this.Controls.Add(this.dynamicGapComboBox);
         this.Controls.Add(this.dynamicGapLabel);
         this.Controls.Add(this.juzComboBox);
         this.Controls.Add(this.selectJuzLabel);
         this.Controls.Add(this.destBrowseButton);
         this.Controls.Add(this.destTextBox);
         this.Controls.Add(this.outputDirLabel);
         this.Controls.Add(this.selectReciterLabel);
         this.Name = "Form1";
         this.Text = "Quran Memorize Tool";
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label selectReciterLabel;
      private System.Windows.Forms.Button destBrowseButton;
      private System.Windows.Forms.TextBox destTextBox;
      private System.Windows.Forms.Label outputDirLabel;
      private System.Windows.Forms.Label selectJuzLabel;
      private System.Windows.Forms.ComboBox juzComboBox;
      private System.Windows.Forms.Label dynamicGapLabel;
      private System.Windows.Forms.ComboBox dynamicGapComboBox;
      private System.Windows.Forms.NumericUpDown fixedGapNumericUpDown;
      private System.Windows.Forms.Label fixedGapLabel;
      private System.Windows.Forms.Label secondsLabel;
      private System.Windows.Forms.ProgressBar totalProgressBar;
      private System.Windows.Forms.Button generateButton;
      private System.Windows.Forms.ComboBox reciterComboBox;
      private System.Windows.Forms.ProgressBar downloadProgressBar;
      private System.Windows.Forms.Label downloadProgressLabel;
      private System.Windows.Forms.Label totalProgressLabel;
      private System.Windows.Forms.Button cancelButton;
   }
}


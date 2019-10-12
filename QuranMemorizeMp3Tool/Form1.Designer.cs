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
         this.label1 = new System.Windows.Forms.Label();
         this.destBrowseButton = new System.Windows.Forms.Button();
         this.destTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.juzComboBox = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.dynamicGapComboBox = new System.Windows.Forms.ComboBox();
         this.fixedGapNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.totalProgressBar = new System.Windows.Forms.ProgressBar();
         this.generateButton = new System.Windows.Forms.Button();
         this.reciterComboBox = new System.Windows.Forms.ComboBox();
         this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.cancelButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(74, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Select Reciter";
         // 
         // destBrowseButton
         // 
         this.destBrowseButton.Location = new System.Drawing.Point(605, 52);
         this.destBrowseButton.Name = "destBrowseButton";
         this.destBrowseButton.Size = new System.Drawing.Size(75, 23);
         this.destBrowseButton.TabIndex = 5;
         this.destBrowseButton.Text = "Browse";
         this.destBrowseButton.UseVisualStyleBackColor = true;
         this.destBrowseButton.Click += new System.EventHandler(this.destBrowseButton_Click);
         // 
         // destTextBox
         // 
         this.destTextBox.Location = new System.Drawing.Point(135, 54);
         this.destTextBox.Name = "destTextBox";
         this.destTextBox.Size = new System.Drawing.Size(444, 20);
         this.destTextBox.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 57);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(84, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Output Directory";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 95);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Select Juz";
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
         this.juzComboBox.Location = new System.Drawing.Point(135, 92);
         this.juzComboBox.Name = "juzComboBox";
         this.juzComboBox.Size = new System.Drawing.Size(189, 21);
         this.juzComboBox.TabIndex = 7;
         this.juzComboBox.Text = "1";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 134);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(71, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Dynamic Gap";
         // 
         // dynamicGapComboBox
         // 
         this.dynamicGapComboBox.FormattingEnabled = true;
         this.dynamicGapComboBox.Items.AddRange(new object[] {
            "No Gap",
            "Half Aya Duration (0.5x)",
            "Same Aya Duration (1x)",
            "One and Half Aya Duration (1.5x)"});
         this.dynamicGapComboBox.Location = new System.Drawing.Point(135, 131);
         this.dynamicGapComboBox.Name = "dynamicGapComboBox";
         this.dynamicGapComboBox.Size = new System.Drawing.Size(256, 21);
         this.dynamicGapComboBox.TabIndex = 9;
         this.dynamicGapComboBox.Text = "Same Aya Duration (1x)";
         // 
         // fixedGapNumericUpDown
         // 
         this.fixedGapNumericUpDown.Location = new System.Drawing.Point(135, 171);
         this.fixedGapNumericUpDown.Name = "fixedGapNumericUpDown";
         this.fixedGapNumericUpDown.Size = new System.Drawing.Size(63, 20);
         this.fixedGapNumericUpDown.TabIndex = 10;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 173);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(108, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "Extra Fixed Time Gap";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(204, 173);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(49, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Seconds";
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
         this.reciterComboBox.Location = new System.Drawing.Point(135, 22);
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
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(9, 315);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(99, 13);
         this.label7.TabIndex = 17;
         this.label7.Text = "Download Progress";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(9, 378);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(75, 13);
         this.label8.TabIndex = 18;
         this.label8.Text = "Total Progress";
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
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.downloadProgressBar);
         this.Controls.Add(this.reciterComboBox);
         this.Controls.Add(this.generateButton);
         this.Controls.Add(this.totalProgressBar);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.fixedGapNumericUpDown);
         this.Controls.Add(this.dynamicGapComboBox);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.juzComboBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.destBrowseButton);
         this.Controls.Add(this.destTextBox);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "Form1";
         this.Text = "Quran Memorize Tool";
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button destBrowseButton;
      private System.Windows.Forms.TextBox destTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox juzComboBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox dynamicGapComboBox;
      private System.Windows.Forms.NumericUpDown fixedGapNumericUpDown;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ProgressBar totalProgressBar;
      private System.Windows.Forms.Button generateButton;
      private System.Windows.Forms.ComboBox reciterComboBox;
      private System.Windows.Forms.ProgressBar downloadProgressBar;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Button cancelButton;
   }
}


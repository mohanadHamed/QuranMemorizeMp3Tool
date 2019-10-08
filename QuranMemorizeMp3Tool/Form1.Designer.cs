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
         this.srcTextBox = new System.Windows.Forms.TextBox();
         this.srcBrowseButton = new System.Windows.Forms.Button();
         this.destBrowseButton = new System.Windows.Forms.Button();
         this.destTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.typeComboBox = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.dynamicGapComboBox = new System.Windows.Forms.ComboBox();
         this.fixedGapNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.button3 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(97, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Source Mp3 Folder";
         // 
         // srcTextBox
         // 
         this.srcTextBox.Location = new System.Drawing.Point(116, 28);
         this.srcTextBox.Name = "srcTextBox";
         this.srcTextBox.Size = new System.Drawing.Size(444, 20);
         this.srcTextBox.TabIndex = 1;
         // 
         // srcBrowseButton
         // 
         this.srcBrowseButton.Location = new System.Drawing.Point(586, 26);
         this.srcBrowseButton.Name = "srcBrowseButton";
         this.srcBrowseButton.Size = new System.Drawing.Size(75, 23);
         this.srcBrowseButton.TabIndex = 2;
         this.srcBrowseButton.Text = "Browse";
         this.srcBrowseButton.UseVisualStyleBackColor = true;
         this.srcBrowseButton.Click += new System.EventHandler(this.srcBrowseButton_Click);
         // 
         // destBrowseButton
         // 
         this.destBrowseButton.Location = new System.Drawing.Point(586, 52);
         this.destBrowseButton.Name = "destBrowseButton";
         this.destBrowseButton.Size = new System.Drawing.Size(75, 23);
         this.destBrowseButton.TabIndex = 5;
         this.destBrowseButton.Text = "Browse";
         this.destBrowseButton.UseVisualStyleBackColor = true;
         this.destBrowseButton.Click += new System.EventHandler(this.destBrowseButton_Click);
         // 
         // destTextBox
         // 
         this.destTextBox.Location = new System.Drawing.Point(116, 54);
         this.destTextBox.Name = "destTextBox";
         this.destTextBox.Size = new System.Drawing.Size(444, 20);
         this.destTextBox.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 57);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(92, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Destination Folder";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 95);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(53, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Join Type";
         // 
         // typeComboBox
         // 
         this.typeComboBox.FormattingEnabled = true;
         this.typeComboBox.Items.AddRange(new object[] {
            "File per Sura",
            "File per Page",
            "File per Juz",
            "File per Hizb",
            "File per 1/2 Hizb",
            "File per 1/4 Hizb"});
         this.typeComboBox.Location = new System.Drawing.Point(116, 92);
         this.typeComboBox.Name = "typeComboBox";
         this.typeComboBox.Size = new System.Drawing.Size(189, 21);
         this.typeComboBox.TabIndex = 7;
         this.typeComboBox.Text = "File per Hizb";
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
            "Current Aya Duration (0.5x)",
            "Current Aya Duration (1x)",
            "Current Aya Duration (1.5x)",
            "Current Aya Duration (2x)",
            "Next Aya Duration (0.5x)",
            "Next Aya Duration (1x)",
            "Next Aya Duration (1.5x)",
            "Next Aya Duration (2x)"});
         this.dynamicGapComboBox.Location = new System.Drawing.Point(116, 131);
         this.dynamicGapComboBox.Name = "dynamicGapComboBox";
         this.dynamicGapComboBox.Size = new System.Drawing.Size(189, 21);
         this.dynamicGapComboBox.TabIndex = 9;
         this.dynamicGapComboBox.Text = "Next Aya Duration (0.5x)";
         // 
         // fixedGapNumericUpDown
         // 
         this.fixedGapNumericUpDown.Location = new System.Drawing.Point(116, 171);
         this.fixedGapNumericUpDown.Name = "fixedGapNumericUpDown";
         this.fixedGapNumericUpDown.Size = new System.Drawing.Size(63, 20);
         this.fixedGapNumericUpDown.TabIndex = 10;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 173);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(81, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "Fixed Time Gap";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(185, 173);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(49, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Seconds";
         // 
         // progressBar
         // 
         this.progressBar.Location = new System.Drawing.Point(16, 300);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(645, 23);
         this.progressBar.TabIndex = 13;
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(271, 256);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(148, 23);
         this.button3.TabIndex = 14;
         this.button3.Text = "Generate Files";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(705, 385);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.progressBar);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.fixedGapNumericUpDown);
         this.Controls.Add(this.dynamicGapComboBox);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.typeComboBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.destBrowseButton);
         this.Controls.Add(this.destTextBox);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.srcBrowseButton);
         this.Controls.Add(this.srcTextBox);
         this.Controls.Add(this.label1);
         this.Name = "Form1";
         this.Text = "Quran Memorize Tool";
         ((System.ComponentModel.ISupportInitialize)(this.fixedGapNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox srcTextBox;
      private System.Windows.Forms.Button srcBrowseButton;
      private System.Windows.Forms.Button destBrowseButton;
      private System.Windows.Forms.TextBox destTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox typeComboBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox dynamicGapComboBox;
      private System.Windows.Forms.NumericUpDown fixedGapNumericUpDown;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.Button button3;
   }
}


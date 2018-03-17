namespace AdvisingAssistant.UI
{
   partial class disciplineName
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
         this.groupBoxCenter = new System.Windows.Forms.GroupBox();
         this.panelMain = new System.Windows.Forms.Panel();
         this.disciplineGroupBox = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.btnNext = new System.Windows.Forms.Button();
         this.groupBoxCenter.SuspendLayout();
         this.disciplineGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxCenter
         // 
         this.groupBoxCenter.Controls.Add(this.panelMain);
         this.groupBoxCenter.Location = new System.Drawing.Point(24, 36);
         this.groupBoxCenter.Name = "groupBoxCenter";
         this.groupBoxCenter.Size = new System.Drawing.Size(936, 995);
         this.groupBoxCenter.TabIndex = 0;
         this.groupBoxCenter.TabStop = false;
         this.groupBoxCenter.Text = "Center Box";
         // 
         // panelMain
         // 
         this.panelMain.AutoScroll = true;
         this.panelMain.Location = new System.Drawing.Point(41, 71);
         this.panelMain.Name = "panelMain";
         this.panelMain.Size = new System.Drawing.Size(766, 644);
         this.panelMain.TabIndex = 0;
         // 
         // disciplineGroupBox
         // 
         this.disciplineGroupBox.Controls.Add(this.label1);
         this.disciplineGroupBox.Location = new System.Drawing.Point(1089, 36);
         this.disciplineGroupBox.Name = "disciplineGroupBox";
         this.disciplineGroupBox.Size = new System.Drawing.Size(746, 963);
         this.disciplineGroupBox.TabIndex = 1;
         this.disciplineGroupBox.TabStop = false;
         this.disciplineGroupBox.Text = "Choose Discipline";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(46, 71);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(327, 37);
         this.label1.TabIndex = 0;
         this.label1.Text = "Select Your Discipline";
         // 
         // btnNext
         // 
         this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnNext.Location = new System.Drawing.Point(1388, 1053);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(496, 175);
         this.btnNext.TabIndex = 2;
         this.btnNext.Text = "Next";
         this.btnNext.UseVisualStyleBackColor = true;
         this.btnNext.Click += new System.EventHandler(this.Class_Click);
         // 
         // disciplineName
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1945, 1276);
         this.Controls.Add(this.btnNext);
         this.Controls.Add(this.disciplineGroupBox);
         this.Controls.Add(this.groupBoxCenter);
         this.Name = "disciplineName";
         this.Text = "ConfigurationForm";
         this.Load += new System.EventHandler(this.ConfigurationForm_Load);
         this.Resize += new System.EventHandler(this.ConfigurationForm_Resize);
         this.groupBoxCenter.ResumeLayout(false);
         this.disciplineGroupBox.ResumeLayout(false);
         this.disciplineGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxCenter;
      private System.Windows.Forms.Panel panelMain;
      private System.Windows.Forms.GroupBox disciplineGroupBox;
      private System.Windows.Forms.Button btnNext;
      private System.Windows.Forms.Label label1;
   }
}
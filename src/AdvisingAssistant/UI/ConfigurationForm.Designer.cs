namespace AdvisingAssistant.UI
{
   partial class ConfigurationForm
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
         this.groupBoxCenter.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxCenter
         // 
         this.groupBoxCenter.Controls.Add(this.panelMain);
         this.groupBoxCenter.Location = new System.Drawing.Point(145, 135);
         this.groupBoxCenter.Name = "groupBoxCenter";
         this.groupBoxCenter.Size = new System.Drawing.Size(1471, 959);
         this.groupBoxCenter.TabIndex = 0;
         this.groupBoxCenter.TabStop = false;
         this.groupBoxCenter.Text = "Center Box";
         // 
         // panelMain
         // 
         this.panelMain.AutoScroll = true;
         this.panelMain.Location = new System.Drawing.Point(63, 170);
         this.panelMain.Name = "panelMain";
         this.panelMain.Size = new System.Drawing.Size(1324, 689);
         this.panelMain.TabIndex = 0;
         // 
         // ConfigurationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1945, 1276);
         this.Controls.Add(this.groupBoxCenter);
         this.Name = "ConfigurationForm";
         this.Text = "ConfigurationForm";
         this.Load += new System.EventHandler(this.ConfigurationForm_Load);
         this.Resize += new System.EventHandler(this.ConfigurationForm_Resize);
         this.groupBoxCenter.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxCenter;
      private System.Windows.Forms.Panel panelMain;
   }
}
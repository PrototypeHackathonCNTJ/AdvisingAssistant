﻿namespace AdvisingAssistant.UI
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
         this.SuspendLayout();
         // 
         // ConfigurationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1945, 1276);
         this.Name = "ConfigurationForm";
         this.Text = "ConfigurationForm";
         this.Load += new System.EventHandler(this.ConfigurationForm_Load);
         this.Resize += new System.EventHandler(this.ConfigurationForm_Resize);
         this.ResumeLayout(false);

      }

      #endregion
   }
}
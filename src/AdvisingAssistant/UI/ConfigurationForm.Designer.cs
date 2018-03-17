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
         this.group_Box_Completed = new System.Windows.Forms.GroupBox();
         this.group_Box_Discipline = new System.Windows.Forms.GroupBox();
         this.group_Box_Optional = new System.Windows.Forms.GroupBox();
         this.SuspendLayout();
         // 
         // group_Box_Completed
         // 
         this.group_Box_Completed.Location = new System.Drawing.Point(710, 603);
         this.group_Box_Completed.Name = "group_Box_Completed";
         this.group_Box_Completed.Size = new System.Drawing.Size(401, 269);
         this.group_Box_Completed.TabIndex = 1;
         this.group_Box_Completed.TabStop = false;
         this.group_Box_Completed.Text = "Completed Courses";
         // 
         // group_Box_Discipline
         // 
         this.group_Box_Discipline.Location = new System.Drawing.Point(222, 918);
         this.group_Box_Discipline.Name = "group_Box_Discipline";
         this.group_Box_Discipline.Size = new System.Drawing.Size(401, 269);
         this.group_Box_Discipline.TabIndex = 2;
         this.group_Box_Discipline.TabStop = false;
         this.group_Box_Discipline.Text = "Choose Discipline";
         // 
         // group_Box_Optional
         // 
         this.group_Box_Optional.Location = new System.Drawing.Point(727, 918);
         this.group_Box_Optional.Name = "group_Box_Optional";
         this.group_Box_Optional.Size = new System.Drawing.Size(401, 269);
         this.group_Box_Optional.TabIndex = 3;
         this.group_Box_Optional.TabStop = false;
         this.group_Box_Optional.Text = "Choose Options";
         // 
         // ConfigurationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1945, 1276);
         this.Controls.Add(this.group_Box_Optional);
         this.Controls.Add(this.group_Box_Discipline);
         this.Controls.Add(this.group_Box_Completed);
         this.Name = "ConfigurationForm";
         this.Text = "ConfigurationForm";
         this.Load += new System.EventHandler(this.ConfigurationForm_Load);
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.GroupBox group_Box_Completed;
      private System.Windows.Forms.GroupBox group_Box_Discipline;
      private System.Windows.Forms.GroupBox group_Box_Optional;
   }
}
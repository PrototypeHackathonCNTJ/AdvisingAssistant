using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvisingAssistant.UI
{
   public partial class ConfigurationForm : Form
   {
      const int BUTTON_SIZE = 125;
      List<String> majors = new List<String>();
      List<Button> completedClasses = new List<Button>();
      List<Button> disciplines = new List<Button>();
      List<Button> optionals = new List<Button>();
      User user = new User();
      public ConfigurationForm()
      {
         InitializeComponent();
         majors.Add("Software Engineering");
         majors.Add("Computer Information Systems");
         majors.Add("Computer Information Technology");
      }

      private void ConfigurationForm_Load(object sender, EventArgs e)
      {
         Show_Majors();
      }

      private void Show_Majors()
      {
         GroupBox group_Box_Major = new GroupBox();
         group_Box_Major.Location = new Point(0, 0);
         group_Box_Major.Width = this.Width;
         group_Box_Major.Height = this.Height;

         for (int i = 0; i < majors.Count; i++)
         {
            Button btn = new Button();
            String name = majors[i];
            btn.Name = "btn_" + name;
            btn.Text = name;

            btn.BackColor = Color.White;
            btn.Width = BUTTON_SIZE;
            btn.Height = BUTTON_SIZE;
            btn.Location = new Point(10 + i * BUTTON_SIZE, 0);
            btn.Click += new EventHandler(Major_Click);
            btn.Show();
            this.Controls.Add(btn);
         }
      }
      private void Major_Click(object sender, EventArgs e)
      {
         //Control gb = Controls.Find("group_Box_Major", true);
        // gb.Visible = false;
        // Button temp = (Button)sender;
        // GroupBox grp = findBox(categoryGrpBxList, temp.Text);
         //grp.Visible = true;

      }
   }
}

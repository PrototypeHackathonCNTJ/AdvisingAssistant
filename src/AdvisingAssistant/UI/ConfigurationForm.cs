using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvisingAssistant.Courses;

namespace AdvisingAssistant.UI
{
   public partial class ConfigurationForm : Form
   {
      const int BUTTON_SIZE = 125;
      List<String> majors = new List<String>();
      GroupBox centerGroupBox = new GroupBox();
      List<Button> completedClasses = new List<Button>();
      List<Button> majorButtons = new List<Button>();
      List<Button> disciplineButtons = new List<Button>();
      List<Button> optionals = new List<Button>();
      User user = new User();
      public ConfigurationForm()
      {
         InitializeComponent();
         centerGroupBox.Name = "pnl_majors";
         centerGroupBox.BackColor = Color.Blue;
         centerGroupBox.Show();
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
         for (int i = 0; i < majors.Count; i++)
         {
            Button btn = new Button();
            String name = majors[i];
            btn.Name = "btn_" + name;
            btn.Text = name;

            btn.BackColor = Color.White;
            btn.Width = BUTTON_SIZE;
            btn.Height = BUTTON_SIZE;
            btn.Location = new Point(centerGroupBox.Location.X + 10 + i * BUTTON_SIZE, centerGroupBox.Location.Y + 10);
            btn.Click += new EventHandler(Major_Click);
            btn.Show();
            centerGroupBox.Controls.Add(btn);
            this.Controls.Add(btn);
            majorButtons.Add(btn);
         }
      }
      private void Show_Discipline()
      {
         for (int i = 0; i < Course.Courses.Count; i++)
         {
            Button btn = new Button();
            String name = Course.Courses.Values.ElementAt(i).Name;
            btn.Name = "btn_" + name;
            btn.Text = Course.Courses.Keys.ElementAt(i) + name;


            btn.BackColor = Color.White;
            btn.Width = BUTTON_SIZE;
            btn.Height = BUTTON_SIZE;
            btn.Location = new Point(centerGroupBox.Location.X + 10 + (i * BUTTON_SIZE) % centerGroupBox.Width, centerGroupBox.Location.Y  + centerGroupBox.Location.Y / centerGroupBox.Height + 10);
            btn.Click += new EventHandler(Discipline_Click);
            btn.Show();
            centerGroupBox.Controls.Add(btn);
            this.Controls.Add(btn);
            disciplineButtons.Add(btn);
         }
      }

      private void Major_Click(object sender, EventArgs e)
      {
         foreach (Button b in majorButtons)
         {
            b.Dispose();
         }
         majorButtons.Clear();
         centerGroupBox.Controls.Clear();

         Show_Discipline();
      }

      private void Discipline_Click(object sender, EventArgs e)
      {
         foreach (Button b in majorButtons)
         {
            b.Dispose();
         }
         majorButtons.Clear();
         centerGroupBox.Controls.Clear();
      }

      private void ConfigurationForm_Resize(object sender, EventArgs e)
      {
         foreach (Button b in majorButtons)
         {
            b.Dispose();
         }
         majorButtons.Clear();
         centerGroupBox.Controls.Clear();

         centerGroupBox.Location = new Point(this.Width / 4, this.Height / 4);
         centerGroupBox.ForeColor = Color.Black;
         centerGroupBox.Width = this.Width / 2;
         centerGroupBox.Height = this.Height / 2;
         centerGroupBox.Anchor = AnchorStyles.Top;
         centerGroupBox.Anchor = AnchorStyles.Bottom;
         centerGroupBox.Anchor = AnchorStyles.Right;
         centerGroupBox.Anchor = AnchorStyles.Left;
         centerGroupBox.Show();

         Show_Majors();
      }
   }
}

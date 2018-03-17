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
            panelMain.Controls.Add(btn);
            majorButtons.Add(btn);
         }
      }

      private void Show_Discipline()
      {
         int groupBoxWidth = groupBoxCenter.Width -(groupBoxCenter.Width % BUTTON_SIZE);//Multiple of button size
         for (int i = 0; i < Course.Courses.Count; i++)
         {
            Button btn = new Button();
            String name = Course.Courses.Values.ElementAt(i).Name;
            btn.Name = "btn_" + name;
            btn.Text = Course.Courses.Keys.ElementAt(i) + "\n" + name;

            btn.BackColor = Color.White;
            btn.Width = BUTTON_SIZE;
            btn.Height = BUTTON_SIZE;
            btn.Location = new Point((i * BUTTON_SIZE) % groupBoxWidth, ((i * BUTTON_SIZE) / groupBoxWidth) * BUTTON_SIZE);
            btn.Click += new EventHandler(Discipline_Click);
            btn.Show();
            panelMain.Controls.Add(btn);
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

         foreach (Button b in disciplineButtons)
         {
            b.Dispose();
         }

         disciplineButtons.Clear();
         majorButtons.Clear();
         panelMain.Controls.Clear();

         groupBoxCenter.Location = new Point(this.Width / 4, this.Height / 4);
         groupBoxCenter.ForeColor = Color.Black;
         groupBoxCenter.Width = this.Width / 2;
         groupBoxCenter.Height = this.Height / 2;
         groupBoxCenter.Show();

         panelMain.Location = new Point(0, 0);
         panelMain.ForeColor = Color.Black;
         panelMain.Width = groupBoxCenter.Width;
         panelMain.Height = groupBoxCenter.Height;
         panelMain.Show();

         Show_Majors();
      }
   }
}

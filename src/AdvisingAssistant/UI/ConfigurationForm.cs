using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvisingAssistant.Majors;
using AdvisingAssistant.Courses;
using AdvisingAssistant.CourseOptionals;

namespace AdvisingAssistant.UI
{
   public partial class ConfigurationForm : Form
   {
      private enum state { SELECT_MAJOR, COMPLETED_COURSES, SELECT_DISCIPLINE, SELECT_OPTIONALS }
      private state currentState = 0;
      const int BUTTON_SIZE = 125;
      List<String> majors = new List<String>();
      Tuple<string[], Optional[]> selectedMajor;
      int currentOption = 0;
      GroupBox centerGroupBox = new GroupBox();
      List<Button> completedClasses = new List<Button>();
      List<Button> majorButtons = new List<Button>();
      List<RadioButton> disciplineButtons = new List<RadioButton>();
      List<CheckBox> optionals = new List<CheckBox>();
      User user = new User();

      public ConfigurationForm()
      {
         InitializeComponent();
         disciplineGroupBox.Hide();
         centerGroupBox.Name = "pnl_majors";
         centerGroupBox.BackColor = Color.Blue;
         centerGroupBox.Show();

         for(int i = 0; i < Major.Majors.Count; i++)
         {
            String name = Major.Majors.Values.ElementAt(i).Name;
            majors.Add(name);
         }

         this.WindowState = FormWindowState.Maximized;
      }

      private void ConfigurationForm_Load(object sender, EventArgs e)
      {
         Show_Majors();
      }

      private void Show_Majors()
      {
         panelMain.Show();
         btnNext.Hide();
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

      private void Show_All_Classes()
      {
         btnNext.Show();
         btnNext.Location = new Point(groupBoxCenter.Location.X + groupBoxCenter.Width - BUTTON_SIZE,
            groupBoxCenter.Location.Y + groupBoxCenter.Height);
         panelMain.Show();
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
            btn.Click += new EventHandler(Class_Selection);
            btn.Show();
            panelMain.Controls.Add(btn);
            completedClasses.Add(btn);
         }
      }

      private void Show_Disciplines()
      {
         disciplineGroupBox.Location = new Point(this.Width / 4, this.Height / 4);
         disciplineGroupBox.ForeColor = Color.Black;
         disciplineGroupBox.Width = this.Width / 2;
         disciplineGroupBox.Height = this.Height / 2;
         disciplineGroupBox.Show();
         centerGroupBox.Hide();
         btnNext.Hide();
         RadioButton cb;
         int i;
         for (i = 0; i < selectedMajor.Item1.Count(); i++)
         {
            cb = new RadioButton();
            cb.Text = selectedMajor.Item1[i];
            cb.Width = disciplineGroupBox.Width - 50;
            cb.Height = 3 * cb.Height;
            cb.Location = new Point( 25, (i + 1) * 50);
            cb.Show();
            disciplineGroupBox.Controls.Add(cb);
            disciplineButtons.Add(cb);
         }
         Button btn = new Button();

         btn.Width = 125;
         btn.Height = 75;
         btn.Text = "Next";
         btn.Location = new Point(10, 50 + (i + 2) * 50);
         btn.Click += new EventHandler(Discipline_Click);
         disciplineGroupBox.Controls.Add(btn);
         btn.Show();
      }

      private void Show_Optionals()
      {
         disciplineGroupBox.Location = new Point(this.Width / 4, this.Height / 4);
         disciplineGroupBox.ForeColor = Color.Black;
         disciplineGroupBox.Width = this.Width / 2;
         disciplineGroupBox.Height = this.Height / 2;
         disciplineGroupBox.Show();
         Optional econ = Optional.GetOptionalByName("SOFTWARE ECON");
         label1.Text = "Select " + selectedMajor.Item2[currentOption].Credits + " credits of the following.";
         label1.Show();
         disciplineGroupBox.Controls.Add(label1);

         int i;
         for (i = 0; i < selectedMajor.Item2[currentOption].Courses.Length; i++)
         {
            CheckBox cb = new CheckBox();
            cb.Width = disciplineGroupBox.Width / 2;
            string name = selectedMajor.Item2[currentOption].Courses[i];
            string creditCount = " (" + Course.GetCourseByID(name).Credits + ")";
            cb.Text = name + creditCount;
            cb.Location = new Point(25, (i + 1) * 50);
            disciplineGroupBox.Controls.Add(cb);
            cb.Show();
         }
         Button btn = new Button();
         btn.Width = 125;
         btn.Height = 75;
         btn.Text = "Next";
         btn.Location = new Point(disciplineGroupBox.Width - 135, disciplineGroupBox.Height - 85);
         btn.Click += new EventHandler(Optional_Click);
         disciplineGroupBox.Controls.Add(btn);
         btn.Show();
      }

      private void Show_Missing_Optionals()
      {
         disciplineGroupBox.Location = new Point(this.Width / 4, this.Height / 4);
         disciplineGroupBox.ForeColor = Color.Black;
         disciplineGroupBox.Width = this.Width / 2;
         disciplineGroupBox.Height = this.Height / 2;
         disciplineGroupBox.Show();
         Optional econ = Optional.GetOptionalByName("SOFTWARE ECON");
         label1.Text = "Select " + selectedMajor.Item2[currentOption].Credits + " credits of the following.";
         label1.Show();
         disciplineGroupBox.Controls.Add(label1);

         int i;
         for (i = 0; i < selectedMajor.Item2[currentOption].Courses.Length; i++)
         {
            CheckBox cb = new CheckBox();
            cb.Width = disciplineGroupBox.Width / 2;
            string name = selectedMajor.Item2[currentOption].Courses[i];
            string creditCount = " (" + Course.GetCourseByID(name).Credits + ")";
            cb.Text = name + creditCount;
            cb.Location = new Point(25, (i + 1) * 50);
            disciplineGroupBox.Controls.Add(cb);
            cb.Show();
         }
         Button btn = new Button();
         btn.Width = 125;
         btn.Height = 75;
         btn.Text = "Next";
         btn.Location = new Point(disciplineGroupBox.Width - 135, disciplineGroupBox.Height - 85);
         btn.Click += new EventHandler(Optional_Click);
         disciplineGroupBox.Controls.Add(btn);
         btn.Show();
      }

      private void Major_Click(object sender, EventArgs e)
      {
         Button btn = (Button)sender;
         selectedMajor = user.ChooseMajor(btn.Text.ToString());
         foreach (var optionalTheUserNeedsToSee in selectedMajor.Item2)
            ;//Show the user their optional and ask them to choose their courses from it.

         foreach (Button b in majorButtons)
            b.Dispose();

         majorButtons.Clear();
         centerGroupBox.Controls.Clear();
         panelMain.Hide();

         currentState++;//Advance the current state
         Show_All_Classes();
      }

      private void Class_Click(object sender, EventArgs e)
      {
         foreach (Button b in completedClasses)
         {
            b.Dispose();
         }

         completedClasses.Clear();
         centerGroupBox.Controls.Clear();
         panelMain.Hide();
         centerGroupBox.Hide();

         currentState++;
         Show_Disciplines();
      }

      private void Discipline_Click(object sender, EventArgs e)
      {
         foreach (RadioButton b in disciplineButtons)
            b.Dispose();

         disciplineButtons.Clear();
         disciplineGroupBox.Controls.Clear();
         panelMain.Hide();
         centerGroupBox.Hide();

         currentState++;
         Show_Optionals();
      }

      private void Optional_Click(object sender, EventArgs e)
      {
         foreach (CheckBox b in optionals)
            b.Dispose();

         optionals.Clear();
         disciplineGroupBox.Controls.Clear();
         panelMain.Hide();
         centerGroupBox.Hide();
         if (currentOption < selectedMajor.Item2.Count() - 1)
         {
            currentOption++;
            Show_Optionals();
         }
         else
         {
            //move onto scheduke display
         }
      }

      private void Select_Class(object sender, EventArgs e)
      {
         CheckBox cb = (CheckBox)sender;

         optionals.Clear();
         disciplineGroupBox.Controls.Clear();
         panelMain.Hide();
         centerGroupBox.Hide();
         if (currentOption < selectedMajor.Item2.Count() - 1)
         {
            currentOption++;
            Show_Optionals();
         }
         else
         {
            //move onto schedule display
         }
      }

      private void Class_Selection(object sender, EventArgs e)
      {
         Button btn = (Button)sender;
         if (btn.BackColor == Color.White)
         {
            btn.BackColor = Color.Blue;
         }
         else
         {
            btn.BackColor = Color.White;
         }
      }

      private void ConfigurationForm_Resize(object sender, EventArgs e)
      {
         foreach (Button b in majorButtons)
         {
            b.Dispose();
         }

         foreach (Button b in completedClasses)
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

         btnNext.Location = new Point(groupBoxCenter.Location.X + groupBoxCenter.Width - BUTTON_SIZE, groupBoxCenter.Location.Y + groupBoxCenter.Height);

         if (currentState == state.SELECT_MAJOR)
            Show_Majors();
         else if (currentState == state.COMPLETED_COURSES)
            Show_All_Classes();
         else if (currentState == state.SELECT_DISCIPLINE)
            Show_Majors();
         else if (currentState == state.SELECT_OPTIONALS)
            Show_Majors();
      }
   }
}

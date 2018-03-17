using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using AdvisingAssistant.UI;

using AdvisingAssistant.Courses;
using AdvisingAssistant.Majors;
using AdvisingAssistant.CourseOptionals;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Course.ReadCoursesFromFile("courses.json");
            Optional.ReadOptionalsFromFile("options.json");
            Major.ReadMajorsFromFile("major.json");

           // Course oops2 = Course.GetCourseByID("COMPUTER 3630");
           // Console.WriteLine("{0}\n", oops2.GetPrereqLayers());

            Application.Run(new ConfigurationForm());
        }
    }
}
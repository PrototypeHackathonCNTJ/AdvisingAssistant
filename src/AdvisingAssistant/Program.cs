﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using AdvisingAssistant.UI;

using AdvisingAssistant.Courses;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
           /* string json = File.ReadAllText(args[0]);

            while (json.IndexOf('}') != -1)
            {
                int nextEndBrace = json.IndexOf('}');
                string obj = json.Substring(0, nextEndBrace + 1);
                json = json.Substring(nextEndBrace + 1);

                Course c = new Course(obj);
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Credits);
                Console.WriteLine(c.Info);
                Console.WriteLine();
            }*/
         Application.Run(new ConfigurationForm());
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdvisingAssistant.Courses;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string json = File.ReadAllText(args[0]);
            Course c = new Course(json);
            Console.WriteLine(c.ID);
            Console.WriteLine(c.Name);
        }
    }
}
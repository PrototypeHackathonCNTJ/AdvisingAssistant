using System;
using System.Collections.Generic;
using System.IO;

using AdvisingAssistant.Courses;

using Newtonsoft.Json;

namespace AdvisingAssistant.CourseOptionals
{
    public class Optional
    {
        public static Dictionary<string, Optional> Optionals = new Dictionary<string, Optional>();
        public static Optional GetOptionalByName(string name)
        {
            if (!Optionals.ContainsKey(name))
                return null;
            return Optionals[name];
        }

        public static void ReadOptionalsFromFile(string path)
        {
			string json = File.ReadAllText(path);

			while (json.IndexOf('}') != -1)
			{
				int nextEndBrace = json.IndexOf('}');
				string obj = json.Substring(0, nextEndBrace + 1);
				json = json.Substring(nextEndBrace + 1);
                Optional o = new Optional(obj);
                if (!Optionals.ContainsKey(o.Name))
                    Optionals.Add(o.Name, o);
			}
        }

        public string Name { get; private set; }
        public int Credits { get; private set; }
        public string[] Courses { get; private set; }
        public List<string> ChosenCourses { get; private set; }
        public int ChosenCredits { get; private set; }

        public Optional(string jsonSource)
        {
            dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonSource);

            Name = json.name;
            Credits = json.credits;
            Courses = json.courses.ToObject<string[]>();

            ChosenCourses = new List<string>();
            ChosenCredits = 0;
        }

        public bool Choose(string course)
        {
            if (ChosenCourses.Contains(course))
                return false;
            foreach (var c in Courses)
            {
                if (c.ToLower() == course.ToLower())
                {
                    ChosenCourses.Add(c);
                    ChosenCredits += Course.GetCourseByName(c).Credits;
                    return ChosenCredits >= Credits;
                }
            }
            return false;
        }

        public void Reset()
        {
            ChosenCourses.Clear();
            ChosenCredits = 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;

using AdvisingAssistant.Courses;

using Newtonsoft.Json;

namespace AdvisingAssistant.CourseOptionals
{
    public class Optional
    {
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
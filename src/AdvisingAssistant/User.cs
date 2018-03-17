using System;
using System.Collections.Generic;

using AdvisingAssistant.CourseOptionals;
using AdvisingAssistant.Courses;
using AdvisingAssistant.Majors;

namespace AdvisingAssistant
{
    public class User
    {
        public Major Major { get; private set; }
        public Optional Discipline { get; private set; }

        public List<Course> ChosenCourses { get; private set; }


    }
}

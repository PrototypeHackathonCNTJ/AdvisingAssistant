using System;
using System.Collections.Generic;

using AdvisingAssistant.Courses;

namespace AdvisingAssistant.ScheduleBuilder
{
    public class Semester
    {
        public Schedule Parent { get; private set; }
        public Dictionary<string, Course> Courses { get; private set; }

        public int SchedulePosition { get; private set; }
		public Term Term { get; private set; }
		public int Year { get; private set; }

        public Semester(Schedule parent, int semesterPosition, Term term)
        {
            Parent = parent;
            Courses = new Dictionary<string, Course>();

            SchedulePosition = semesterPosition;
            Year = (semesterPosition - (semesterPosition % 2) / 2);
            Term = term;
        }

        public void AddCourse(string name)
        {
            AddCourse(name, Course.GetCourseByID(name));
        }
        public void AddCourse(string name, Course course)
        {
            if (!Courses.ContainsKey(name))
                Courses.Add(name, course);
        }

        public bool ContainsCourse(string name)
        {
            return Courses.ContainsKey(name);
        }
    }
}

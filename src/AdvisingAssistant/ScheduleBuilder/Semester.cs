using System;
using System.Collections.Generic;

using AdvisingAssistant.Courses;

namespace AdvisingAssistant.ScheduleBuilder
{
    public class Semester
	{
		public const int SEMESTER_CREDITS = 0xF;

        public Schedule Parent { get; private set; }
        public Dictionary<string, Course> Courses { get; private set; }

        public int SchedulePosition { get; private set; }
		public Term Term { get; private set; }
		public int Year { get; private set; }

        private int takenCredits = 0;

        public Semester(Schedule parent, int semesterPosition, Term term)
        {
            Parent = parent;
            Courses = new Dictionary<string, Course>();

            SchedulePosition = semesterPosition;
            Year = (semesterPosition - (semesterPosition % 2) / 2);
            Term = term;
        }

        public bool AddCourse(string name)
        {
            return AddCourse(name, Course.GetCourseByID(name));
        }
        public bool AddCourse(Course course)
        {
            return AddCourse(course.Name, course);
        }
        public bool AddCourse(string name, Course course)
        {
            if (IsFilled()) return false;
            if (!Courses.ContainsKey(name))
            {
                Courses.Add(name, course);
                takenCredits += course.Credits;
                return IsFilled();
            }
            return false;
        }

        public bool ContainsCourse(string name)
        {
            return Courses.ContainsKey(name);
        }

        public bool IsFilled()
        {
            return takenCredits >= SEMESTER_CREDITS;
        }
    }
}

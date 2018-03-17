using System;
using System.Collections.Generic;

using AdvisingAssistant.CourseOptionals;
using AdvisingAssistant.Courses;
using AdvisingAssistant.Majors;

namespace AdvisingAssistant.ScheduleBuilder
{
    public class Schedule
    {
        public Semester[] Semesters { get; private set; }

        public Schedule(User user)
        {
            Semesters = new Semester[8];
        }


    }
}

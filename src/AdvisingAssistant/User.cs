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

        public Tuple<Optional[], Optional[]> ChooseMajor(string major)
        {
            Major = Major.GetMajorByName(major);

            foreach (string courseID in Major.CoreRequirements)
                ChosenCourses.Add(Course.GetCourseByName(courseID));

            var disciplineOptions = new List<Optional>();
            var coreOptions = new List<Optional>();

            foreach (var courseID in Major.DisciplineOptions)
                disciplineOptions.Add(Optional.GetOptionalByName(courseID));
            foreach (var courseID in Major.Options)
                coreOptions.Add(Optional.GetOptionalByName(courseID));

            return new Tuple<Optional[], Optional[]>(disciplineOptions.ToArray(), coreOptions.ToArray());
        }
    }
}

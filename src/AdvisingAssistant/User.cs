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

        public Dictionary<string, Course> ChosenCourses { get; private set; }

        public User()
        {
            ChosenCourses = new Dictionary<string, Course>();
        }

        public Tuple<string[], Optional[]> ChooseMajor(string major)
        {
            Major = Major.GetMajorByName(major);

            foreach (string courseID in Major.CoreRequirements)
                ChosenCourses.Add(courseID, Course.GetCourseByName(courseID));

            var optionals = new List<Optional>();
            foreach (string courseID in Major.Options)
                optionals.Add(Optional.GetOptionalByName(courseID));

            return new Tuple<string[], Optional[]>(Major.DisciplineOptions, optionals.ToArray());
        }

        public Optional ChooseDiscipline(string disc)
        {
            return Optional.GetOptionalByName(disc);
        }

        public void SubmitOptional(Optional opt)
        {
            foreach (var courseID in opt.ChosenCourses)
                if (!ChosenCourses.ContainsKey(courseID))
                    ChosenCourses.Add(courseID, Course.GetCourseByName(courseID));
        }
    }
}

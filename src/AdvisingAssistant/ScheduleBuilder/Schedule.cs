using System;
using System.Collections.Generic;

using AdvisingAssistant.CourseOptionals;
using AdvisingAssistant.Courses;
using AdvisingAssistant.Majors;

namespace AdvisingAssistant.ScheduleBuilder
{
    public class Schedule
    {

        public static void TestSchedule()
        {
            User cole = new User();
            cole.ChooseMajor("Software Engineering");

            Schedule schedule = new Schedule(cole);
            var order = schedule.generateOrderedCourses();
            foreach (var pair in order)
            {
                Console.Write("{0}\t", pair.Key);
                foreach (var c in pair.Value)
                    Console.Write("{0} ", c.ID);
                Console.WriteLine();
            }
        }

        public Semester[] Semesters { get; private set; }

        public User User { get; private set; }

        private Course[] layerOrderedCourses;

        public Schedule(User user)
        {
            Semesters = new Semester[8];
            for (int i = 1; i <= Semesters.Length; i++) Semesters[i - 1] = new Semester(this, i);

            User = user;
        }

        public void GenerateSemesters()
        {
            for (int i = Semesters.Length - 1; i >= 0; i--)
            {
                Semester s = Semesters[i];


            }
        }

        public Semester GetEnrolledSemester(string course)
        {
            return GetEnrolledSemester(Course.GetCourseByID(course));
        }
        public Semester GetEnrolledSemester(Course course)
        {
            foreach (var semester in Semesters)
                if (semester.ContainsCourse(course.Name))
                    return semester;
            return null;
        }

        private Dictionary<int, List<Course>> generateOrderedCourses()
        {
            var orderedCourses = new Dictionary<int, List<Course>>();
            int highestLayerCount = 0;
            foreach (var course in User.ChosenCourses.Values)
            {
                if (course == null) continue;
                int layers = course.GetPrereqLayers();
                if (layers > highestLayerCount)
                    highestLayerCount = layers;
                if (!orderedCourses.ContainsKey(layers))
                    orderedCourses.Add(layers, new List<Course>() { course });
                else
                    orderedCourses[layers].Add(course);
            }

            return orderedCourses;
        }
    }
}

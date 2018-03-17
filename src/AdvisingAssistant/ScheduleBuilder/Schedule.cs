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

            Schedule schedule = new Schedule(cole, Term.Spring);
            schedule.generateOrderedCourses();

            for (int i = 0; i < schedule.layerOrderedCourses.Length; i++)
                Console.WriteLine(schedule.layerOrderedCourses[i].ID);

            for (int i = 0; i < schedule.Semesters.Length; i++)
                Console.WriteLine("{0} {1}", schedule.Semesters[i].SchedulePosition, schedule.Semesters[i].Term);
        }

        public Semester[] Semesters { get; private set; }

        public User User { get; private set; }

        private Course[] layerOrderedCourses;
        private Term startingTerm;

        public Schedule(User user, Term startingTerm)
        {
            Semesters = new Semester[8];

            Term term = startingTerm;
            for (int i = 0; i < Semesters.Length; i++)
            {
                Semesters[i] = new Semester(this, i + 1, term);
                term = (Term)((int)term ^ 1);
            }

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

        private void generateOrderedCourses()
        {
            var orderedCourses = new Dictionary<int, List<Course>>();
            int highestLayerCount = 0;
            int courseCount = 0;
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
                courseCount++;
            }

            layerOrderedCourses = new Course[courseCount];
            int layeredOrderedCoursesIndex = 0;
            for (int i = highestLayerCount; i >= 0; i--)
                if (orderedCourses.ContainsKey(i))
                    foreach (var course in orderedCourses[i])
                        layerOrderedCourses[layeredOrderedCoursesIndex++] = course;
        }
    }
}

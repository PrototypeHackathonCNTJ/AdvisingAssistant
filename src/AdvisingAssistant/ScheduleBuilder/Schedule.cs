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

            for (int i = 0; i < schedule.layerOrderedCourses.Count; i++)
                Console.WriteLine(schedule.layerOrderedCourses[i].ID);

			schedule.GenerateSemesters();

            for (int i = 0; i < schedule.Semesters.Length; i++)
            {
                Console.WriteLine("{0} {1}", schedule.Semesters[i].SchedulePosition, schedule.Semesters[i].Term);
                foreach (var course in schedule.Semesters[i].Courses)
                    Console.WriteLine("\t{0}", course.Value.ID);
            }

        }

        public Semester[] Semesters { get; private set; }

        public User User { get; private set; }

        private List<Course> layerOrderedCourses;

        public Schedule(User user, Term startingTerm)
        {
            Semesters = new Semester[80];

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
            var courses = layerOrderedCourses.ToArray();
            for (int i = 0; i < courses.Length; i++)
            {
                var course = courses[i];
                addCourseToNextAvailable(course);
                generateSemestersProreq(course);
            }
        }
        private void generateSemestersProreq(Course course)
        {
            foreach (var proreq in course.Proreqs)
            {
                var c = Course.GetCourseByID(proreq);
                if (!layerOrderedCourses.Contains(c)) continue;
                addCourseToFollowingAvailable(c);
                generateSemestersProreq(c);
            }
        }

        private void addCourseToNextAvailable(Course course)
        {
            if (!User.TakingCourse(course) || !layerOrderedCourses.Contains(course)) return;
            Semesters[nextAvailableSemesterIndex()].AddCourse(course);
            layerOrderedCourses.Remove(course);
        }
        private void addCourseToFollowingAvailable(Course course)
        {
            if (!User.TakingCourse(course) || !layerOrderedCourses.Contains(course)) return;
            Semesters[nextAvailableSemesterIndex() + 1].AddCourse(course);
            layerOrderedCourses.Remove(course);
        }

        private int nextAvailableSemesterIndex()
        {
            for (int i = 0; i < Semesters.Length; i++)
                if (!Semesters[i].IsFilled())
                    return i;
            return -1;
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

            layerOrderedCourses = new List<Course>();
            for (int i = 0; i < highestLayerCount; i++)
                if (orderedCourses.ContainsKey(i))
                    foreach (var course in orderedCourses[i])
                        layerOrderedCourses.Add(course);
        }
    }
}

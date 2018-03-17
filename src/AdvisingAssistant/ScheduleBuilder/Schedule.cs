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

            Schedule schedule = new Schedule(cole, Term.Fall);
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

		private List<Course> scheduledCourses;
		public void GenerateSemesters()
		{
			scheduledCourses = new List<Course>();
			var courses = layerOrderedCourses.ToArray();
			foreach (var course in courses)
			{
				addCourse(course, 0);
				addProreqs(course, 0);
			}
		}
        public void addCourse(Course course, int index)
        {
            if (Semesters[index].IsFilled() || !course.Validate(Semesters[index], this, User))
            {
                addCourse(course, index + 1);
                return;
            }
            if (scheduledCourses.Contains(course) || !layerOrderedCourses.Contains(course))
                return;
            Semesters[index].AddCourse(course);
            addProreqs(course, index);
            scheduledCourses.Add(course);
        }

		private void addProreqs(Course course, int index)
		{
			foreach (var proreq in course.Proreqs)
			{
				var c = Course.GetCourseByID(proreq);
				addCourse(c, index + 1);
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

		private List<Course> layerOrderedCourses;
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

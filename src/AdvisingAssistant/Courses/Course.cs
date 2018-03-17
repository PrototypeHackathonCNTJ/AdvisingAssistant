using System.Collections.Generic;
using System.IO;

using AdvisingAssistant.ScheduleBuilder;

using Newtonsoft.Json;
using System;

namespace AdvisingAssistant.Courses
{
	public class Course
	{
#region static
        public static Dictionary<string, Course> Courses = new Dictionary<string, Course>();

		public static void TestCourses()
		{
			foreach (var crs in Courses.Values)
			{
				Console.Write("{0}\tProreqs ({1}):", crs.ID, crs.Proreqs.Count);
				foreach (var proreq in crs.Proreqs)
					Console.Write("\t{0}", proreq);
				Console.WriteLine();
			}
		}

		public static Course GetCourseByID(string name)
		{
			if (!Courses.ContainsKey(name))
				return null;
			return Courses[name];
		}

		public static void AssignProreqs()
		{
			foreach (var course in Courses.Values)
				foreach (string prereq in course.Prereqs)
					if (Course.GetCourseByID(prereq) != null)
						Course.GetCourseByID(prereq).Proreqs.Add(course.ID);
		}

		public static void ReadCoursesFromFile(string path)
		{
			string json = File.ReadAllText(path);

			while (json.IndexOf('}') != -1)
			{
				int nextEndBrace = json.IndexOf('}');
				string obj = json.Substring(0, nextEndBrace + 1);
				json = json.Substring(nextEndBrace + 1);
				Course c = new Course(obj);
				if (!Courses.ContainsKey(c.Name))
					Courses.Add(c.ID, c);
			}
			Course.AssignProreqs();
		}
#endregion


        public List<string> Proreqs { get; private set; }
		public string ID { get; private set; }
		public string Name { get; private set; }
		public string[] Prereqs { get; private set; }
		public string PrereqStanding { get; private set; }
		public int Credits { get; private set; }
		public string Info { get; private set; }
		public bool OfferFall { get; private set; }
		public bool OfferFallEven { get; private set; }
		public bool OfferFallOdd { get; private set; }
		public bool OfferSpring { get; private set; }
		public bool OfferSpringEven { get; private set; }
		public bool OfferSpringOdd { get; private set; }
		public bool OfferSummer { get; private set; }
		public bool OfferWinter { get; private set; }
		public Classification[] Classifications { get; private set; }

		public Course(string jsonSource)
		{
			dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonSource);

			ID = json.id;
			Name = json.name;
			Prereqs = json.prereqs.ToObject<string[]>();
			PrereqStanding = json.prereqStanding;
			Credits = json.credits;
			Info = json.info;
			OfferFall = json.offerFall;
			OfferFallEven = json.offerFallEven;
			OfferFallOdd = json.offerFallOdd;
			OfferSpring = json.offerSpring;
			OfferSpringEven = json.offerSpringEven;
			OfferSpringOdd = json.offerSpringOdd;
			OfferSummer = json.offerSummer;
			OfferWinter = json.offerWinter;
			Classifications = ParseClassifications(json.classification.ToObject<string[]>());

			Proreqs = new List<string>();
		}

		public int GetPrereqLayers()
		{
			int highestLater = 0;

			if (Prereqs.Length == 0) return 0;

			foreach (var prereq in Prereqs)
			{
				Course c = GetCourseByID(prereq);
				int subLayers = c.GetPrereqLayers();
				if (highestLater < subLayers)
					highestLater = subLayers;
			}

			return highestLater + 1;
		}

		/// <summary>
		/// Validates this course against a schedule and requested semester.
		/// </summary>
		/// <returns>False if the course is in the wrong term or a prereq is taken later.</returns>
		/// <param name="semester">Semester.</param>
		/// <param name="schedule">Schedule.</param>
		/// <param name="user">User.</param>
		public bool Validate(Semester semester, Schedule schedule, User user)
		{
			/*foreach (var prereq in Prereqs)
			{
				var enrolledSemester = schedule.GetEnrolledSemester(prereq);

                if (enrolledSemester == null) return false;
				if (enrolledSemester.SchedulePosition >= semester.SchedulePosition)
					return false;
			}*/
			return true;
		}

		public static Classification[] ParseClassifications(string[] classes)
		{
			List<Classification> classifications = new List<Classification>();
			foreach (var clazz in classes)
			{
				switch (clazz.ToLower())
				{
					case "socialscience":
						classifications.Add(AdvisingAssistant.Courses.Classification.SocialScience);
						break;
				}
			}
			return classifications.ToArray();
		}
	}
}
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    public class Course
    {
        public static Dictionary<string, Course> Courses = new Dictionary<string, Course>();
        public static Course GetCourseByID(string name)
        {
            if (!Courses.ContainsKey(name))
                return null;
            return Courses[name];
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
        }

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
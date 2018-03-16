using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    public class Course
    {
        public static Dictionary<string, Course> Courses = new Dictionary<string, Course>();

        public string ID { get; private set; }
        public string Name { get; private set; }
        public string[] Prereqs { get; private set; }
        public string PrereqStanding { get; private set; }
        public int Credits { get; private set; }
        public string Info { get; private set; }
        public Offering[] Offerings { get; private set; }
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
            Offerings = ParseOfferings(json.offerings.ToObject<string[]>());
            Classifications = ParseClassifications(json.classifications.ToObject<string[]>());
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

        public static Offering[] ParseOfferings(string[] times)
        {
            List<Offering> offerings = new List<Offering>();
            foreach (var offer in times)
            {
                switch (offer.ToLower())
                {
                    case "fall":
                        offerings.Add(Offering.Fall);
                        break;
                }
            }
            return offerings.ToArray();
        }
    }
}

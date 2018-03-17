using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace AdvisingAssistant.Majors
{
    public class Major
    {
        public static Dictionary<string, Major> Majors = new Dictionary<string, Major>();
        public static Major GetMajorByName(string name)
        {
            if (!Majors.ContainsKey(name))
                return null;
            return Majors[name];
        }

        public string Name { get; private set; }
        public string[] CoreRequirements { get; private set; }
        public string[] DisciplineOptions { get; private set; }
        public string[] Options { get; private set; }

        public Major(string jsonSource)
        {
            dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonSource);

            Name = json.name;
            CoreRequirements = json.core.ToObject<string[]>();
            DisciplineOptions = json.discipline.ToObject<string[]>();
            Options = json.discipline.ToObject<string[]>();

            if (!Majors.ContainsKey(Name))
                Majors.Add(Name, this);
        }
    }
}

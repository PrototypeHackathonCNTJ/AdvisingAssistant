using System;
using System.Collections.Generic;
using System.IO;

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

        public static void ReadMajorsFromFile(string path)
        {
			string json = File.ReadAllText(path);

			while (json.IndexOf('}') != -1)
			{
				int nextEndBrace = json.IndexOf('}');
				string obj = json.Substring(0, nextEndBrace + 1);
				json = json.Substring(nextEndBrace + 1);
                Major m = new Major(obj);
				if (!Majors.ContainsKey(m.Name))
					Majors.Add(m.Name, m);
			}
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

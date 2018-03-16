using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace AdvisingAssistant.Courses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string json = @"{ 
                ""Name"": ""test1"",
                ""reqs"": [ 1, 2, 3 ]
            }";

            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            string name = results.Name;
            int first = results.reqs.ToObject<int[]>()[0];
            Console.WriteLine("Name: {0}, reqs: {1}", name, first);
        }
    }
}
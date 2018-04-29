using AdvisingAssistant.CourseOptionals;
using AdvisingAssistant.Courses;
using AdvisingAssistant.Majors;
using AdvisingAssistant.ScheduleBuilder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvisingAssistant.UI
{
   public class TUI
   {
      public void Run()
      {
         List<Course> chosenCourses = new List<Course>();

         Major major = SelectMajor();
         if (major.DisciplineOptions.Length > 0)
         {
            Optional discipline = SelectDiscipline(major);
            foreach (var course in SelectOptionalCourses(discipline).ChosenCourses)
               chosenCourses.Add(Course.Courses[course]);
         }
         foreach (var optional in major.Options)
            foreach (var course in SelectOptionalCourses(Optional.Optionals[optional]).ChosenCourses)
               chosenCourses.Add(Course.Courses[course]);
         foreach (var course in major.CoreRequirements)
            if (Course.Courses.ContainsKey(course))
            chosenCourses.Add(Course.Courses[course]);


         Schedule schedule = new Schedule(chosenCourses, Term.Fall);
         schedule.GenerateOrderedCourses();
         schedule.GenerateSemesters();

         for (int i = 0; i < schedule.Semesters.Length; i++)
         {
            Console.WriteLine("{0} {1}", schedule.Semesters[i].SchedulePosition, schedule.Semesters[i].Term);
            foreach (var course in schedule.Semesters[i].Courses)
               Console.WriteLine("\t{0}", course.Value.ID);
         }
      }

      public Major SelectMajor()
      {
         Major result = null;
         do
         {
            foreach (var major in Major.Majors)
               Console.WriteLine(major.Key);
            Console.Write("Select your major> ");
            string input = Console.ReadLine();
            if (Major.Majors.ContainsKey(input))
               result = Major.Majors[input];
         } while (result == null);
         return result;
      }

      public Optional SelectDiscipline(Major major)
      {
         Optional result = null;
         do
         {
            foreach (var optional in major.DisciplineOptions)
            {
               Console.WriteLine(optional);
               foreach (var course in Optional.Optionals[optional].Courses)
                  Console.WriteLine("\t{0}", course);
            }
            Console.Write("Select your discipline> ");
            string input = Console.ReadLine();
            if (major.DisciplineOptions.Contains(input))
               result = Optional.Optionals[input];
         } while (result == null);
         return result;
      }

      public Optional SelectOptionalCourses(Optional optional)
      {
         while (optional.ChosenCredits < optional.Credits)
         {
            Console.WriteLine("Select {0} credits in {1}:", optional.Credits - optional.ChosenCredits, optional.Name);
            foreach (var course in optional.Courses)
               Console.WriteLine("\t{0}  {1}", course, Course.Courses[course].Credits);
            Console.WriteLine("Select a course> ");
            string input = Console.ReadLine();
            optional.Choose(input);
         }
         return optional;
      }
   }
}

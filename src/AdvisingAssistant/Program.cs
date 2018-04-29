using System;

namespace AdvisingAssistant
{
   public class Program
   {
      public static void Main(string[] args)
      {
         Courses.Course.ReadCoursesFromFile("courses.json");
         CourseOptionals.Optional.ReadOptionalsFromFile("options.json");
         Majors.Major.ReadMajorsFromFile("major.json");

        // ScheduleBuilder.Schedule.TestSchedule();
         //Console.ReadLine();
         new UI.TUI().Run();
         Console.ReadLine();
      }
   }
}
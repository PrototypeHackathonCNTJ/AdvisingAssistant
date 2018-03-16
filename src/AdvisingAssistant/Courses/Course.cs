using System;

namespace AdvisingAssistant.Courses
{
    public class Course
    {
        public Classification Classification { get; private set; }
        public string CourseID { get; private set; }
        public string CourseDescription { get; private set; }
        public int PassingGrade { get; private set; }
        public Course[] PrerequisiteCourses { get; private set; }
        public string SemesterOffered { get; private set; }

        public Course(Classification classification, string courseID, string courseDesc, int passingGrade, Course[] prerequisites, string semester)
        {
            Classification = classification;
            CourseID = courseID;
            CourseDescription = courseDesc;
            PassingGrade = passingGrade;
            PrerequisiteCourses = prerequisites;
            SemesterOffered = semester;
        }
    }
}

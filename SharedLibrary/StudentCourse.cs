using System;
using System.Collections.Generic;

namespace SharedLibrary
{
    public class StudentCourse
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseCreated { get; set; }

        public List<GradeTest> GradeTests;
        public List<ILTest> ILTests;
        public List<DyslexiaTest> OrdblindeTests;
        public List<NonOrdTest> NonordTests;
    }
}
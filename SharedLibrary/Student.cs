using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary
{
    public class Student
    {
        public string Id { get; set; }
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int ClassLevel { get; set; }
        public bool ActiveStudent { get; set; }
        public string SchoolClass { get; set; }


        public List<StudentCourse> Courses;


        [CreatedAt]
        public string AzureCreated { get; set; }

        [UpdatedAt]
        public string AzureUpdated { get; set; }

        [Version]
        public string AzureVersion { get; set; }
    }
}
using SharedLibrary;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class StudentRepository
    {
        AzureService azureService = new AzureService();
        private List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = "1",
                StudentId = 1,
                StudentFirstName = "Jørn",
                StudentLastName="Andersen",
                ClassLevel = 3,
                ActiveStudent = true,
                SchoolClass = "3b"
            },
            new Student
            {
                Id = "2",
                StudentId = 2,
                StudentFirstName = "Kasper",
                StudentLastName = "Rasmussen",
                ClassLevel = 1,
                ActiveStudent = true,
                SchoolClass = "4c"
            },
            new Student
            {
                Id = "3",
                StudentId = 3,
                StudentFirstName = "Emil",
                StudentLastName="Larsen",
                ClassLevel=2,
                ActiveStudent = true,
                SchoolClass = "2a"
            },
            new Student
            {
                Id = "9",
                StudentId = 150,
                StudentFirstName = "Thomas",
                StudentLastName = "Siebenhaar",
                ClassLevel=3,
                ActiveStudent = true,
                SchoolClass = "1c"
            }
        };
        //private List<Student> _students = new List<Student>();


        public List<Student> GetStudents()
        {
            return _students;
        }

        //public async Task<List<Student>> GetStudents()
        //{
        //    var result = await azureService.GetStudents();
        //    foreach (var student in result)
        //    {
        //        _students.Add(student);
        //    }
        //    return _students;
        //}
        public Student GetStudent(string id)
        {
            return (from s in _students
                    where s.StudentId.ToString() == id
                    select s).FirstOrDefault();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Exam.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Lecture> Lectures { get; set; }

        public Student() { }
        public Student(string firstName, string lastName, int departmentId)
        {
            FirstName = firstName;
            LastName = lastName;
            DepartmentId = departmentId;
            Lectures = new List<Lecture>();

        }
    }
}


using Entity_Framework_Exam.Entities;
using Entity_Framework_Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sql_exam
{
    internal class DbRepository
    {
        private readonly StudentsInformationSystemDbContext _dbContext;
        public DbRepository()
        {
            _dbContext = new StudentsInformationSystemDbContext();
        }
        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
        }
        public void AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
        }
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
        }
        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.Id == id);
        }
        public Lecture GetLectureById(int id)
        {
            return _dbContext.Lectures.FirstOrDefault(x => x.Id == id);
        }
        public Student GetStudentsById(int id)
        {
            return _dbContext.Students.FirstOrDefault(x => x.Id == id);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<Department> GetAllDepartmentsOrdered()
        {
            var depar = _dbContext.Departments.OrderBy(x => x.Id).ToList();
            foreach (var department in depar)
            {
                Console.WriteLine($"\n{department.Id} - {department.Name}\n");
            }
            return depar;
        }
        public List<Lecture> GetAllLecturesOrdered()
        {
            var lectur = _dbContext.Lectures.OrderBy(x => x.Id).ToList();
            foreach (var lecture in lectur)
            {
                Console.WriteLine($"\n{lecture.Id} - {lecture.Name}\n");
            }
            return lectur;
        }
        public List<Student> GetAllStudentsOrdered()
        {
            var student = _dbContext.Students.OrderBy(x => x.Id).ToList();
            foreach (var stud in student)
            {
                Console.WriteLine($"\n{stud.Id}, {stud.FirstName}, {stud.LastName}, Department Id - {stud.DepartmentId}");
            }
            return student;
        }
        public List<Student> GetAllSameDepartmentStudents(int depId)
        {
            return _dbContext.Students.OrderBy(x => x.Id).ToList().Where(y => y.DepartmentId == depId).ToList();
        }
        public Department GetDepartmentWithLectures(int id)
        {
            return _dbContext.Departments.Include(x => x.Lectures).FirstOrDefault(y => y.Id == id);
        }
        public Student GetStudentWithLectures(int id)
        {
            return _dbContext.Students.Include(x => x.Lectures).FirstOrDefault(y => y.Id == id);
        }
        public void UpdateDepartment(Department department)
        {
            _dbContext.Attach(department);
        }
        public void UpdateStudent(Student student)
        {
            _dbContext.Attach(student);
        }
        public void LecturesFromSameDepartment(int id)
        {

        }
        public List<Department> RetrieveDepartments()
        {
            return _dbContext.Departments.Include(x => x.Lectures).Include(x => x.Students).ToList();
        }
        public List<Lecture> RetrieveLectures()
        {
            return _dbContext.Lectures.Include(x => x.Departments).Include(x => x.Students).ToList();
        }
        public List<Student> RetrieveStudents()
        {
            return _dbContext.Students.Include(x => x.Lectures).ToList();
        }
    }
}

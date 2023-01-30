
using Entity_Framework_Exam;
using Entity_Framework_Exam.Entities;
using sql_exam;

using var dbContext = new StudentsInformationSystemDbContext();

//var department = new Department("Sciences");
//var department = new Department("Humanities");
//var department = new Department("Business");
//dbContext.Departments.Add(department);
//dbContext.SaveChanges();

//var lecture = new Lecture("Physics");
//var lecture = new Lecture("Sociology");
//var lecture = new Lecture("Management");
//dbContext.Lectures.Add(lecture);
//dbContext.SaveChanges();

//var student = new Student("Tom", "Jones", 1);
//var student = new Student("Sarah", "Connor", 2);
//var student = new Student("Bill", "Gates", 3);
//dbContext.Students.Add(student);
//dbContext.SaveChanges();




var functionality = new Functionality();

ProgramInit();

void ProgramInit()
{
    Console.WriteLine("Welcome to student information system");
    Console.ReadLine();

    bool repeat = true;
    string userInput;
    while (repeat)
    {
        Console.Clear();
        Console.WriteLine("1 - Create a department and assign lectures and students\n" + // Task 1
            "2 - Assign lectures to a departament\n" + // Task 2
            "3 - Assign students to a departament\n" + // Task 2
            "4 - Create a lecture and assign to an existing departament\n" + // Task 3
            "5 - Create a student and assign existing departament and lectures\n" + // Task 4
            "6 - Move a student to a different departament\n" + // Task 5
            "7 - Display all students from a single departament\n" + // Task 6
            "8 - Display all lectures from a single departament\n" + // Task 7
            "9 - Display all lectures of a single student\n" + // Task 8
            "0 - Log out");
        userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                Console.Clear();
                CreateDepartmentWithAssignments();
                break;
            case "2":
                Console.Clear();
                AssignLectureToDepartment();
                break;
            case "3":
                Console.Clear();
                AsssignStudentToDepartment();
                break;
            case "4":
                Console.Clear();
                CreateLectureAndAssignToDepartment();
                break;
            case "5":
                Console.Clear();
                CreateStudentAddLecturesAndDepartment();
                break;
            case "6":
                Console.Clear();
                MoveStudent();
                break;
            case "7":
                Console.Clear();
                StudentsFromSameDepartment();
                break;
            case "8":
                Console.Clear();
                LecturesFromSameDepartment();
                break;
            case "9":
                Console.Clear();
                StudentsFromSameLecture();
                break;
            case "0":
                Console.Clear();
                repeat = false;
                break;
        }
    }
}


void CreateDepartment()
{
    Console.WriteLine("Please enter the name of a new departament");
    var name = Console.ReadLine();
    functionality.CreateDepartment(name);
    Console.WriteLine("Departament created, to continue press enter, to quit press 0");
}
void CreateLecture()
{
    Console.WriteLine("Please enter the name of a new lecture");
    var name = Console.ReadLine();
    functionality.CreateLecture(name);
    Console.WriteLine("Lecture created");
}
void CreateStudent()
{
    Console.WriteLine("Please enter the first name of the new student");
    var firstName = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Please enter the last name of the new student");
    var lastName = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Please enter the departament id of the new student");
    functionality.GetDepartments();
    var departmentId = int.Parse(Console.ReadLine());
    Console.Clear();
    functionality.CreateStudent(firstName, lastName, departmentId);
    Console.WriteLine("Student created");
}
void AssignLectureToStudent()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the student to assign the lecture to\n");
        functionality.GetStudents();
        var studId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the lecture id\n");
        functionality.GetLectures();
        var lectId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.AssignLectureToStudent(studId, lectId);
        Console.Clear();
        Console.WriteLine("Lecture added, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }

}
void CreateDepartmentWithAssignments()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the name of the new departament");
        var name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please enter the lecture id");
        functionality.GetLectures();
        var lectId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the student id");
        functionality.GetStudents();
        var studId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.CreateDepartmentWithStudentsAndLectures(name, lectId, studId);
        Console.WriteLine("Department created, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void AssignLectureToDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the departament to assign lecture to\n");
        functionality.GetDepartments();
        var depId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the id of the lecture\n");
        functionality.GetLectures();
        var lectId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.AssignLectureToDepartment(depId, lectId);
        Console.WriteLine("Lecture assigned, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void AsssignStudentToDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the departament to assign student to\n");
        functionality.GetDepartments();
        var depId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the id of the student");
        functionality.GetStudents();
        var studId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.AssignStudentToDepartment(depId, studId);
        Console.WriteLine("Student assigned, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void CreateLectureAndAssignToDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the name of the new lecture");
        var name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please enter the departments id");
        functionality.GetDepartments();
        var depId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.CreateLectureAndAssignToDepartment(name, depId);
        Console.WriteLine("Lecture created and assigned, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void CreateStudentAddLecturesAndDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the first name of the new student");
        var firstName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please enter the last name of the new student");
        var lastName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please enter the departments id");
        functionality.GetDepartments();
        var depId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the lecture id");
        functionality.GetLectures();
        var lectId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.CreateStudentAddLecturesAndDepartment(firstName, lastName, depId, lectId);
        Console.WriteLine("Student created, lecture and departament added, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void MoveStudent()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the student");
        functionality.GetStudents();
        var studId = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Please enter the id of the departament");
        functionality.GetDepartments();
        var depId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.MoveStudent(studId, depId);
        Console.WriteLine("Student moved, to continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void StudentsFromSameDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the departament");
        functionality.GetDepartments();
        var id = int.Parse(Console.ReadLine());
        var oneDepStudents = functionality.StudentsSameDepartment(id);
        foreach (var student in oneDepStudents)
        {
            Console.WriteLine($"{student.Id}, {student.FirstName}, {student.LastName}\n");
        }
        Console.WriteLine("To continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void LecturesFromSameDepartment()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the departament");
        functionality.GetDepartments();
        var id = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.LecturesFromSameDepartment(id);
        Console.WriteLine("To continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
void StudentsFromSameLecture()
{
    bool repeat = true;
    while (repeat)
    {
        Console.WriteLine("Please enter the id of the departament");
        functionality.GetStudents();
        var studId = int.Parse(Console.ReadLine());
        Console.Clear();
        functionality.LecturesFromSameStudent(studId);
        Console.WriteLine("To continue press enter, to quit press 0");
        if (Console.ReadLine() == "0")
        {
            repeat = false;
        }
    }
}
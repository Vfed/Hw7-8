using System;

namespace Hw8
{
    public enum TeacherProf { 
        junior = 1,
        middel = 2,
        senior = 3};
    class BasePerson {
        public string Name { get; set; }
        public string Surname { get; set; }
        public BasePerson( string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
    class Student : BasePerson {
        public Student( string name, string surname) : base( name, surname)
        { }
    }
    class Teacher : BasePerson
    {
        public TeacherProf TeacherProfency { get; private set; }
        public Teacher( string name, string surname, TeacherProf teacherProf) : base(name, surname)
        {
            this.TeacherProfency = teacherProf;
        }
    }
    class Lesson {
        public string LessonTheam { get; set; }
        public Lesson(string theam)
        {
            this.LessonTheam = theam;
        }
    }
    class Course {
        public string CourseName { get; set; }
        public Lesson[] CourseLessons { get; set; }
        public Course(int lessonsNumber, string courseName)
        {
            this.CourseName = courseName;
            this.CourseLessons = new Lesson[lessonsNumber];
            for (int j = 0; j < lessonsNumber; j++)
            {
                string lessontheam = "";
                do
                {
                    Console.Write("Lesson " + (j + 1) + " theam : ");
                    lessontheam = Console.ReadLine();
                    this.CourseLessons[j] = new Lesson(lessontheam);
                } while (!new Validator().SetMinLength(lessontheam, 3));
            }
        }
        public Course(Course course)
        {
            this.CourseName = course.CourseName;
            this.CourseLessons = new Lesson[course.CourseLessons.Length];
            for (int j = 0; j < this.CourseLessons.Length; j++)
            {
                this.CourseLessons[j] = new Lesson(course.CourseLessons[j].LessonTheam);
            }
        }
    }
    class Group {
        public Course GroupCourse { get; set; }
        public string GroupName { get; set; }
        public Teacher GroupTeacher { get; set; }
        public Student[] Students { get; set; }
        public Grade GroupGrades { get; set; }
        public Group(Course course)
        {
            Validator valid = new Validator();
            this.GroupCourse = course;
            string groupName = "";
            do
            {
                Console.Write("Enter Group Name :");
                groupName = Console.ReadLine();
            } while (!valid.SetMinLength(groupName, 3));
            this.GroupName = groupName;
            string teacherName = "";
            do
            {
                Console.Write("Enter Group Teacher Name:");
                teacherName = Console.ReadLine();
            } while (!valid.SetMinLength(teacherName, 3));
            string teacherSurname = "";
            do
            {
                Console.Write("Enter Group Teacher Surname:");
                teacherSurname = Console.ReadLine();
            } while (!valid.SetMinLength(teacherSurname, 3));
            int teacherProf = 0;
            bool teacherProfChek = false;
            TeacherProf teacherProfency = TeacherProf.junior;
            do
            {
                Console.Write("Enter Group Teacher profency (junior(1)/middle(2)/senior(3)):");

                teacherProfChek = Int32.TryParse(Console.ReadLine(), out teacherProf);
                if (valid.IsProf(teacherProf))
                {
                    teacherProfency = (TeacherProf)teacherProf;
                }
                else { teacherProfChek = false; }
            } while (!teacherProfChek);
            this.GroupTeacher = new Teacher(teacherName, teacherSurname, teacherProfency);

            bool NumberCheck = false;
            int studentsNumber = 0;
            do
            {
                Console.Write("Enter Group Students number: ");
                NumberCheck = Int32.TryParse(Console.ReadLine(), out studentsNumber);

            } while (!NumberCheck && studentsNumber > 0);
            this.Students = new Student[studentsNumber];
            for (int i = 0; i < this.Students.Length; i++)
            {
                string studentSurname = "";
                string studentName = "";
                do
                {
                    Console.Write("Enter Group Student Name:");
                    studentName = Console.ReadLine();
                    Console.Write("Enter Group Student Surname:");
                    studentSurname = Console.ReadLine();
                } while (!valid.SetMinLength(studentName, 3) || !valid.SetMinLength(studentSurname, 3));
                this.Students[i] = new Student(studentName,studentSurname);
            }
            this.GroupGrades = new Grade(this.Students.Length, this.GroupCourse.CourseLessons.Length);
        }
        public void ShowGroupGrades() {
            Console.WriteLine("\t Course "+ this.GroupCourse );
            Console.WriteLine("\t Group "+this.GroupName);
            Console.WriteLine(new String('_', 30));
            for (int i = 0; i < this.GroupCourse.CourseLessons.Length; i++)
            {
                Console.Write((i + 1) + "\t");
            }
            Console.WriteLine("");
            for (int i = 0; i < this.Students.Length; i++)
            {
                Console.Write(this.Students[i].Name+" "+this.Students[i].Surname+new String(' ', 30 -(this.Students[i].Name.Length + 1 + this.Students[i].Surname.Length)));
                for (int j = 0; j < this.GroupGrades.Grades.GetLength(1); j++)
                {
                    Console.Write(this.GroupGrades.Grades[i, j] + "\t");
                }
            } 
        }
    }
    class Grade {
        public int[,] Grades { get; set; }
        public Grade(int studentsNum, int lessonsNum)
        {
            this.Grades = new int[studentsNum, lessonsNum];
        }
        public Grade(Grade grade) {
            this.Grades = new int[grade.Grades.GetLength(0), grade.Grades.GetLength(0)];
            for (int i = 0; i < this.Grades.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grades.GetLength(1); j++)
                {
                    this.Grades[i, j] = grade.Grades[i, j];
                }
            }
        }
    }
    class University {
        public Course[] UniCourses { get; private set; }
        public Group[] UniGroupes { get; private set; }
        public void AddNewCourse()
        {
            int courseNum = this.UniCourses.Length;
            Course[] newCourse = new Course[courseNum + 1];
            for (int i = 0; i < courseNum; i++)
            {
                newCourse[i] = this.UniCourses[i];
            }
            string newCourseName = Console.ReadLine();
            Console.WriteLine("Enter number of lessons");
            bool lessonsNumCheck = Int32.TryParse(Console.ReadLine(), out int lessonsNum);
            newCourse[newCourse.Length - 1] = new Course(lessonsNum, newCourseName);
            this.UniCourses = newCourse;
        }
        public void AddNewGroup()
        {
            int groupNum = this.UniGroupes.Length;
            Group[] newGroup = new Group[groupNum + 1];
            for (int i = 0; i < groupNum; i++)
            {
                newGroup[i] = this.UniGroupes[i];
            }
            string newCourseName = Console.ReadLine();
            int courseNum = 0;
            bool coureseNumCheck = false;
            do
            {
                Console.WriteLine("Chose what course to study (wtite number) :");
                this.ShowCourse();
                coureseNumCheck = Int32.TryParse(Console.ReadLine(), out courseNum);
                if ((courseNum < 0) || (courseNum >= this.UniCourses.Length))
                {
                    coureseNumCheck = false;
                    Console.WriteLine("Wrong Enter;");
                }
            } while (!coureseNumCheck);
            newGroup[newGroup.Length - 1] = new Group(this.UniCourses[courseNum]);
            this.UniGroupes = newGroup;
        }
        public void ShowCourse(){
            for (int i = 0; i < this.UniCourses.Length; i++)
            {
                Console.WriteLine((i+1)+". "+ this.UniCourses[i].CourseName);
            }
        }
        public void ShowCourseLessons() {
            this.ShowCourse();
            int courseNum = 0;
            bool coureseNumCheck = false;
            do
            {
                Console.WriteLine("Chose what course to show (wtite number) :");
                this.ShowCourse();
                coureseNumCheck = Int32.TryParse(Console.ReadLine(), out courseNum);
                if ((courseNum <= 0) || (courseNum >= this.UniCourses.Length))
                {
                    coureseNumCheck = false;
                    Console.WriteLine("Wrong Enter;");
                }
            } while (!coureseNumCheck);

            Console.Clear();
            Console.WriteLine("Course (" + courseNum + ") " + this.UniCourses[courseNum - 1].CourseName);
            for (int i = 0; i < this.UniCourses[courseNum-1].CourseLessons.Length; i++)
            {
                Console.WriteLine("\t"+(i + 1) + ". " + this.UniCourses[courseNum - 1].CourseLessons[i].LessonTheam);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            University univer = new University();
        }
    }
}

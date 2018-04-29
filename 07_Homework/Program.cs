using System;
using System.Collections.Generic;

namespace _Homework
{
    class MainClass
    {
        static School school;
        public static void Main(string[] args)
        {
            school = new School();//建一个新学校（也就是三条list）
            seed();

            //Main menu
			while(true){
				Console.WriteLine("Choose option");
				Console.WriteLine("1. For course managemnet");
				Console.WriteLine("2. For student managemnet");
                int option = Int32.Parse(Console.ReadLine());//输入的操作
                Console.Clear();//清屏
                switch(option){
                    case 1:
                        courseOption();//如果用户输入的是1
                        break;
					case 2:
						studentOption();//如果用户输入的是2
                        break;
                    default:
                        break;
				}
			}
        }

        // To inital the course and student
        public static void seed(){
			school.addCourse("FullStack 101");
			school.addCourse("Mobile Development 101");
			school.addCourse("Mobile Development 201");
			school.addCourse("Interview Drill 101");

			school.addStudent("Tony", 21);
			school.addStudent("Adam", 21);
			school.addStudent("Barney", 21);
			school.addStudent("Robin", 21);
			school.addStudent("Ted", 21);
			school.addStudent("Lily", 21);

		}

        public static void courseOption(){
			Console.WriteLine("Course menu - Choose option");
			Console.WriteLine("1. Adding Course");
			Console.WriteLine("2. Remove Course");
			Console.WriteLine("3. Course Report");
			Console.WriteLine("4. Print All Course");
			Console.WriteLine("5. Enroll student to course");

			int option = Int32.Parse(Console.ReadLine());
			Console.Clear();

			switch (option)
			{
				case 1:
					Console.WriteLine("Please input name of course");
					string name = Console.ReadLine();
					school.addCourse(name);
					break;
				case 2:
					Console.Clear();
					school.printStudent();
					Console.WriteLine("Which course do you want to remove?");
                    //所以说输入的是course的id而不是course的名字
					int studentSelectedIdx = Int32.Parse(Console.ReadLine()) - 1;
                    school.removeStudent(studentSelectedIdx);
					Console.Clear();
					Console.WriteLine("New List of Course:");
					break;
                case 3:
					school.printCourse();
					Console.WriteLine("Which course you want see the report?");
					int idx = Int32.Parse(Console.ReadLine()) - 1;
                    Console.Clear();
					school.printCourseWithCourseIndex(idx);
					break;
				case 4:
                    school.printCourse();
                    break;
                case 5:
					school.printCourse();
					Console.WriteLine("Which course you want to the student to enroll?");
                    int courseSelectedIdx  = Int32.Parse(Console.ReadLine()) - 1;
                    Console.Clear();
					school.printStudent();
					Console.WriteLine("Which student you want to enroll in this course?");
                    studentSelectedIdx = Int32.Parse(Console.ReadLine()) - 1;
					Console.Clear();
					school.enrollStudentToCourse(courseSelectedIdx,studentSelectedIdx);
                    school.printCourseToStudent();
					break;
				default:
					break;
			}
        }
		public static void studentOption()
		{
			Console.WriteLine("Student menu - Choose option");
			Console.WriteLine("1. Adding Student");
			Console.WriteLine("2. Remove Student");
			Console.WriteLine("3. Print All Student");

			int option = Int32.Parse(Console.ReadLine());
			Console.Clear();

			switch (option)
			{
				case 1:
					Console.WriteLine("Please input name of student");
                    string name = Console.ReadLine();
                    Console.WriteLine("Input credit limited");
					int creditLimited = Int32.Parse(Console.ReadLine());
                    school.addStudent(name, creditLimited);
					break;
				case 2:
					//school.removeCourse();
					Console.WriteLine("Which stduent de you want to remove?");
					school.printStudent();
					int studentSelectedIdx = Int32.Parse(Console.ReadLine()) - 1;
                    school.removeStudent(studentSelectedIdx);
					break;
				case 3:
                    school.printStudent();
					break;
				default:
					break;
			}
		}
    }
}

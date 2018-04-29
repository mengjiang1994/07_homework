using System;
using System.Collections.Generic;

namespace _Homework
{
	public class School
	{
		private const int FEE_PER_CREDIT = 1000;  //这东西定义过之后就再也没有用过 = =
        private List<Student> students;           //一个学校有许多学生，所以需要list，这里用list需要System.COllections.Generic;
		private List<Course> courses;             //同学生
		private List<CourseToStudent> courseToStudents;

        //school is the instructor of this class，包含了上面的全部
        public School()
		{
			this.students = new List<Student>();
			this.courses = new List<Course>();
			this.courseToStudents = new List<CourseToStudent>();
		}

        //增加课程: 把新课加到courses这个list里面
		public void addCourse(string name)
		{
            //TODO:Add course
            Course course = new Course(name);
            courses.Add(course);
		}

        //增加学生：把新学生加入到students这个list中
		public void addStudent(string name, int creditLimited)
		{
            //TODO:Add student
            Student student = new Student(name, creditLimited);
            students.Add(student);

		}

        //在CTSs中加入一个新的CTS(cI,sI);
		public void enrollStudentToCourse(int courseIndex, int studentIndex)
		{   
            //若不存在，则enroll，否则就因为已经enrolled而不能enroll
			if (checkStudentCanEnroll(students[studentIndex], courses[courseIndex]))
			{
                //TODO:Insert the record in courseToStudents
                CourseToStudent courseToStudent = new CourseToStudent(courses[courseIndex], students[studentIndex]);
                courseToStudents.Add(courseToStudent);

			}
			else
			{
				Console.WriteLine("Student " + students[studentIndex].name + "can not enroll");
			}
		}

        //检查学生是否可以enroll，只有 A 和 B 都通过了才可以（学生和课程的相互检查）
		private bool checkStudentCanEnroll(Student student, Course course)
		{
			//Check course max student 
			return (checkCourseCanTakeStudent(course) && checkStudentCanTakeCourse(student, course));

		}

        //A 检查这门课是不是还有足够的空位让新学生参加，有的话就返回true
		private bool checkCourseCanTakeStudent(Course course)
		{
			List<Student> studentsInCourse = getStudentsFromCourse(course);
			return (studentsInCourse.Count < course.maxStudent);
            //课程的最大学生人数要小于已经参与了这门课的学生的人数才算是可以
		}

        //B 检车这个学生的已修学分加上这门课的学分有没有到达必修学分的上限，没有达到的话就返回true
		private bool checkStudentCanTakeCourse(Student student, Course courseWillEnrolled)
		{
			List<Course> courseStudentTaking = getCourseFromStudent(student);
			int maxCredit = student.creditLimited;
			int studentCredit = 0;
			foreach (Course course in courseStudentTaking)
			{
				studentCredit = studentCredit + course.credit;
			}
			return (studentCredit + courseWillEnrolled.credit) <= maxCredit;
		}

		//打印出所有的students
        public void printStudent()
		{
			//TODO:print all Student
            for(int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].name);
            }

		}
		
        //打印出所有的courses
        public void printCourse()
		{
			//TODO:print all Course
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(courses[i].className);
            }

		}

        //通过学生的id移除学生，并且移除CourseToStudent里面的纪录
		public void removeStudent(int studentIdx)
		{
			Student selectedStudent = students[studentIdx];
			foreach (CourseToStudent courseTostudent in courseToStudents.ToArray())
			{
				if (courseTostudent.student == selectedStudent)
				{
					courseToStudents.Remove(courseTostudent);
				}
			}
			students.Remove(selectedStudent);
		}

        //删除课程还有这个课程所有有相关的的CourseToStudnets纪录
		public void removeCourse(int courseIdx)
		{
			Course selectedCourse = courses[courseIdx];
			foreach (CourseToStudent courseTostudent in courseToStudents.ToArray())
			{
				if (courseTostudent.course == selectedCourse)
				{
					courseToStudents.Remove(courseTostudent);

				}
			}
			courses.Remove(selectedCourse); ;
		}
       
        //返回出上了这门课的所有学生的list
		private List<Student> getStudentsFromCourse(Course course)
		{
            //TODO:Get the student list from course
            List<Student> studentFromCourse = new List<Student>();
            foreach (CourseToStudent courseTostudent in courseToStudents.ToArray())
            { 
                if(course == courseTostudent.course){
                    studentFromCourse.Add(courseTostudent.student);
                    //每个couresToStudent有两个值，course和student，所以这里取出student是没问题的
                }
            }

            return studentFromCourse;
		}

        //返回出这个学生enroll的所有course 的list
        //和上面的方法基本上一样，只是把student换成了course
		private List<Course> getCourseFromStudent(Student student)
		{
			//TODO:Get the course list from studemt
            List<Course> courseFromStudent = new List<Course>();
            foreach (CourseToStudent courseTostudent in courseToStudents.ToArray())
            {
                if (student == courseTostudent.student)
                {
                    courseFromStudent.Add(courseTostudent.course);
                }
            }

            return courseFromStudent;
		}

        //输入courseid
        //先打印出1. courseName - studentName
        //再打印出参加这门课的学生总数
		public void printCourseWithCourseIndex(int courseIndex)
		{
			Course selectedCourse = courses[courseIndex];
			int count = 0;
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				if (courseToStudents[i].course == selectedCourse)
				{
					Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
					count++;
				}
			}
			Console.WriteLine("The total student of " + selectedCourse.className + " : " + count);
		}

        //输入学生ID
        //先打印出1. courseName - studentName
        //再打印出这位学生enroll课程的总数
		public void printCourseWithStudentIndex(int studentIdx)
		{
			Student selectedStudent = students[studentIdx];
			int count = 0;
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				if (courseToStudents[i].student == selectedStudent)
				{
					Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
					count++;
				}
			}
			Console.WriteLine("The total course of " + selectedStudent.name + " enrolled is " + count);

		}

        //打印出所有CourseToStudent的纪录
		public void printCourseToStudent()
		{
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
			}
		}
	}
}

﻿using System;
using System.Collections.Generic;

namespace _Homework
{
	public class School
	{
		private const int FEE_PER_CREDIT = 1000;
		private List<Student> students;
		private List<Course> courses;
		private List<CourseToStudent> courseToStudents;

		public School()
		{
			this.students = new List<Student>();
			this.courses = new List<Course>();
			this.courseToStudents = new List<CourseToStudent>();
		}

		public void addCourse(string name)
		{
            //TODO:Add course
            Course course = new Course(name);
            courses.Add(course);
		}

		public void addStudent(string name, int creditLimited)
		{
            //TODO:Add student
            Student student = new Student(name, creditLimited);
            students.Add(student);

		}

		public void enrollStudentToCourse(int courseIndex, int studentIndex)
		{
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

		private bool checkStudentCanEnroll(Student student, Course course)
		{
			//Check course max student 
			return (checkCourseCanTakeStudent(course) && checkStudentCanTakeCourse(student, course));

		}

		private bool checkCourseCanTakeStudent(Course course)
		{
			List<Student> studentsInCourse = getStudentsFromCourse(course);
			return (studentsInCourse.Count < course.maxStudent);
		}

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

		
        public void printStudent()
		{
			//TODO:print all Student
            for(int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].name);
            }

		}
		
        public void printCourse()
		{
			//TODO:print all Course
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(courses[i].className);
            }

		}

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
       
		private List<Student> getStudentsFromCourse(Course course)
		{
            //TODO:Get the student list from course
            List<Student> studentFromCourse = new List<Student>();
            foreach (CourseToStudent courseTostudent in courseToStudents.ToArray())
            { 
                if(course == courseTostudent.course){
                    studentFromCourse.Add(courseTostudent.student);
                }
            }

            return studentFromCourse;
		}

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

		public void printCourseToStudent()
		{
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
			}
		}
	}
}

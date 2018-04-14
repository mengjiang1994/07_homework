using System;
namespace _Homework
{
    public class Student
    {
		public string name;
		public int creditLimited;

		public Student(string name, int creditLimited)
		{
			this.name = name;
			this.creditLimited = creditLimited;
		}

        //Below is added on course
        public static string GetTitle(Student student){
            return "MR" + student.name;
            //Console.WriteLine("MR" + student.name);
        }

        //public string GetTitleFromStudent

    }
}

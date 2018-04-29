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

        //以下是在上课期间写上去的
        public static string GetTitle(Student student){
            return "MR" + student.name;
            //Console.WriteLine("MR" + student.name);
        }

        //public string GetTitleFromStudent

    }
}

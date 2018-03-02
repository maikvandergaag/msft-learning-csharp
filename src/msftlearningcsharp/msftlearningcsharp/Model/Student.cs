using System.Collections.Generic;

namespace msftlearningcsharp.Model
{
    public class Student : Person
    {
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

        public double Costs()
        {
            return 1;
        }
    }
}

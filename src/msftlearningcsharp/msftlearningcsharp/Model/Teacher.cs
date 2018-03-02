using System.Collections.Generic;

namespace msftlearningcsharp.Model
{
    public class Teacher : Person
    {
        public List<Course> Courses { get; set; }

        public Teacher()
        {
            Courses = new List<Course>();
        }
    }
}

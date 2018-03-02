using System.Collections.Generic;

namespace msftlearningcsharp.Model
{
    public class CourseClass
    {
        public ClassRoom Room {get;set;}

        public Teacher Teacher { get; private set; }

        public List<Student> Students { get; set; }

        public string Course { get; set; }

        public bool Full
        {
            get
            {
                bool retVal = true;

                if(Room != null)
                {
                    int total = 1 + Students.Count;
                    retVal = total >= Room.Size;                   
                }

                return retVal;
            }
        }

        public CourseClass(Teacher teacher)
        {
            Teacher = teacher;
            Students = new List<Student>();
        }
    }
}

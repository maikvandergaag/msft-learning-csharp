using msftlearningcsharp.Model;
using System;

namespace msftlearningcsharp
{
    class Program
    {

        private static CourseClass Course = null;

        private 

        static void Main(string[] args)
        {
            bool proceed = true;

            while (proceed)
            {
                Console.WriteLine("What action would you like to perform (s = add student, c = create Class Room, t = enough machines, r = full, a = calculate average age) ? ");
                string action = Console.ReadLine().ToUpperInvariant();

                switch (action)
                {
                    case "S":
                        if(Course == null)
                        {
                            Console.WriteLine("A class room needs to be initiated first.");
                        }
                        else
                        {
                            Course.Students.Add(AddStudent());
                        }
                        break;
                    case "C":

                        bool create = true;
                        if(Course != null)
                        {
                            Console.WriteLine("Would you like to initiate a new class room (y = yes, n = no)?");
                            string newClass = Console.ReadLine();
                            create = newClass.ToUpperInvariant() == "N" ? false : true;
                        }

                        if (create)
                        {
                            Course = CreateCourseClass();
                        }
                        break;
                    case "T":
                        string message = $"Enough machines: {Course.Room.AmountMachines > Course.Students.Count}";
                        Console.WriteLine(message);
                        break;
                    case "R":
                        string messageFull = $"Is the room full: {Course.Full}";
                        Console.WriteLine(messageFull);
                        break;
                    case "A":
                        if (Course == null)
                        {
                            Console.WriteLine("A class room needs to be initiated first.");
                        }
                        else
                        {
                            int total = 0;
                            int count = 0;

                            total +=  Course.Teacher.Age;
                            count++;

                            foreach(Student student in Course.Students)
                            {
                                count++;
                                total += student.Age;
                            }

                            double average = total / count;

                            Console.WriteLine($"Average age is: {average}");
                        }
                        break;
                    default:
                        Console.WriteLine("Please specify an action?");
                        break;
                }


                Console.WriteLine("Would you like to proceed (y = yes, n = no)?");
                string pro = Console.ReadLine();
                proceed = pro.ToUpperInvariant() == "Y" ? true : false;
                Console.Clear();
            }


        }

        private static CourseClass CreateCourseClass()
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("Name Teacher:");
            teacher.Name = Console.ReadLine();

            Console.WriteLine("Lastmame Teacher:");
            teacher.LastName = Console.ReadLine();

            Console.WriteLine("Year of Birth:");
            int year = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Month of Birth (1....12):");
            int month = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Day of Birth (1....12):");
            int day = Convert.ToInt16(Console.ReadLine());

            teacher.DateofBirth = new DateTime(year, month, day);

            Console.WriteLine("Courses seperated by ';'");
            string[] courses = Console.ReadLine().Split(new string[]{ ";" }, StringSplitOptions.RemoveEmptyEntries) ;

            foreach(string course in courses)
            {
                teacher.Courses.Add(new Course() { Name = course });
            }

            ClassRoom room = new ClassRoom();
            Console.WriteLine("Room Floor:");
            room.Floor = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Room Number:");
            room.Number = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Room Size:");
            room.Size = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Amount of machines:");
            room.AmountMachines = Convert.ToInt16(Console.ReadLine());


            CourseClass courseClass = new CourseClass(teacher);
            courseClass.Room = room;

            return courseClass;
        }


        public static Student AddStudent()
        {
            Student student = new Student();
            Console.WriteLine("Name Student:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Lastmame Student:");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Year of Birth (****):");
            int year = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Month of Birth (1....12):");
            int month = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Day of Birth (1....12):");
            int day = Convert.ToInt16(Console.ReadLine());

            student.DateofBirth = new DateTime(year, month, day);

            return student;
        }
    }
}

using System;

namespace msftlearningcsharp.Model
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime DateofBirth { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DateofBirth.Year;
                if (DateTime.Now < DateofBirth.AddYears(age)) age--;

                return age;
            }
        }

        public Person() {
            Id = new Guid();
        }
    }
}

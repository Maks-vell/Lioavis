using System;

namespace ConsoleApp1
{
    public struct Student
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int Birthday { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
    }
    
    class Program
    {
        private static Student[] _students = new Student[5];

        static void Main(string[] args)
        {  
            _students[0].Name ="Maksim";
            _students[0].Family = "Vyalmisov";
            _students[0].Birthday = 2003;
            _students[0].Course = 2;
            _students[0].Group = "20VV1";
            
            _students[0].Name ="Pavel";
            _students[0].Family = "Ivkin";
            _students[0].Birthday = 2002;
            _students[0].Course = 2;
            _students[0].Group = "20VO1";

            _students[0].Name ="lol";
            _students[0].Family = "kek";
            _students[0].Birthday = 1;
            _students[0].Course = 0;
            _students[0].Group = "____";
            
            Console.Write("Enter name: ");
            string enteredName = Console.ReadLine();
            Console.Write("Enter family: ");
            string enteredFamily = Console.ReadLine();
            Console.Write("Enter birthday: ");
            int enteredBirthday = int.Parse(Console.ReadLine() ?? string.Empty);

            bool founded=false;
            foreach (Student student in _students)
            {
                if (student.Name == enteredName && student.Family == enteredFamily &&
                    student.Birthday == enteredBirthday)
                {
                    Console.WriteLine("Student found: ");
                    Console.WriteLine("Course:" + student.Course);
                    Console.WriteLine("Group: "+ student.Group);
                    founded = true;
                }
            }

            if (!founded)
            {
                Console.WriteLine("Student not found");
            }
            
        }
    }
    
}
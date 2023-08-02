using System;
using TeacherRecordSystemAssesmentofSL;

namespace TeacherRecordSystemAssesmentofSL
{
    class Program
    {
        static void Main()
        {
            TeacherDataAccess dataAccess = new TeacherDataAccess();

            while (true)
            {
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTeacher(dataAccess);
                        break;
                    case "2":
                        UpdateTeacher(dataAccess);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private static void AddTeacher(TeacherDataAccess dataAccess)
        {
            Console.Write("Enter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class and Section: ");
            string classAndSection = Console.ReadLine();

            Teacher teacher = new Teacher
            {
                ID = id,
                Name = name,
                ClassAndSection = classAndSection
            };

            dataAccess.AddTeacher(teacher);
            Console.WriteLine("Teacher added successfully!");
        }

        private static void UpdateTeacher(TeacherDataAccess dataAccess)
        {
            Console.Write("Enter Teacher ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Teacher existingTeacher = dataAccess.GetAllTeachers().Find(t => t.ID == id);
            if (existingTeacher == null)
            {
                Console.WriteLine("Teacher with the specified ID not found!");
                return;
            }

            Console.Write("Enter updated Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter updated Class and Section: ");
            string classAndSection = Console.ReadLine();

            Teacher updatedTeacher = new Teacher
            {
                ID = id,
                Name = name,
                ClassAndSection = classAndSection
            };

            dataAccess.UpdateTeacher(updatedTeacher);
            Console.WriteLine("Teacher updated successfully!");
            Console.ReadKey();
        }
    }
}


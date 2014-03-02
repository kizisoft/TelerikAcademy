// 2. Define abstract class Human with first name and last name. Define new class
//    Student which is derived from Human and has new field – grade. Define class 
//    Worker derived from Human with new property WeekSalary and WorkHoursPerDa
//    and method MoneyPerHour() that returns money earned by hour by the worker.
//    Define the proper constructors and properties for this hierarchy. Initialize
//    a list of 10 students and sort them by grade in ascending order (use LINQ or
//    OrderBy() extension method). Initialize a list of 10 workers and sort them
//    by money per hour in descending order. Merge the lists and sort them by
//    first name and last name.

namespace _02.Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HumansTest
    {
        public static void Main(string[] args)
        {
            const int NUMBER_OF_ELEMENTS = 10;

            string[] constFirstNames = { "Ivan", "Stoian", "Petar", "Georgi", "Todor", "Mihail", "Boris", "Kalin", "Iskren", "Boian", "Plamen", "Hristo", "Ivo", "Ognian", "Dimitar", "Nikolai" };
            string[] constLastNames = { "Ivanov", "Stoianov", "Petov", "Georgiev", "Todorov", "Mihailov", "Borisov", "Kalinov", "Iskrenov", "Boianov", "Plamenov", "Hristoev", "Marinov", "Ognianov", "Dimitarov", "Nikolaiev" };

            int len1 = constFirstNames.Length;
            int len2 = constLastNames.Length;

            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();

            Random rnd = new Random();

            // Generate random instances for Student and Worker
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                Student student = new Student(constFirstNames[rnd.Next(len1)], constLastNames[rnd.Next(len2)], rnd.Next(101));
                students.Add(student);

                Worker worker = new Worker(constFirstNames[rnd.Next(len1)], constLastNames[rnd.Next(len2)], (decimal)(100 + (rnd.NextDouble() * 300)), rnd.Next(20, 41));
                workers.Add(worker);
            }

            // List of Humans to mearge students and workers
            List<Human> humans = new List<Human>();

            // Print sorted list of students and add them to the human list
            Console.WriteLine("Students sorted by Grage:");
            var sortedStudents = students.OrderBy(x => x.Grade);
            foreach (var item in sortedStudents)
            {
                humans.Add(item);
                Console.WriteLine(item);
            }

            // Print sorted list of workers and add them to the human list
            Console.WriteLine();
            Console.WriteLine("Workers sorted by money per hour:");
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            foreach (var item in sortedWorkers)
            {
                humans.Add(item);
                Console.WriteLine(item);
            }

            // Print sorted human list
            Console.WriteLine();
            Console.WriteLine("Humans sorted by first and last name:");
            var sortedHumans = from human in humans
                               orderby human.FirstName, human.LastName
                               select human;
            Console.WriteLine(string.Join(Environment.NewLine, sortedHumans));
        }
    }
}
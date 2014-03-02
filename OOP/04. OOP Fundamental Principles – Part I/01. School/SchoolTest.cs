// 1. We are given a school. In the school there are classes of students. Each class
//    has a set of teachers. Each teacher teaches a set of disciplines. Students have
//    name and unique class number. Classes have unique text identifier. Teachers have
//    name. Disciplines have name, number of lectures and number of exercises. Both
//    teachers and students are people. Students, classes, teachers and discipline
//    could have optional comments (free text block).
//    Your task is to identify the classes (in terms of  OOP) and their attributes and
//    operations, encapsulate their fields, define the class hierarchy and create a
//    class diagram with Visual Studio.

namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class SchoolTest
    {
        public static void Main(string[] args)
        {
            School school = new School("Test School", "One of the best schools in the city!");

            List<Student> students11A = new List<Student>()
            {
                new Student("Petar", "Petrov", 1),
                new Student("Ivan", "Petrov", 2),
                new Student("Stoian", "Ivanov", 3, "Excelant student!"),
                new Student("Gosho", "Toshev", 4),
                new Student("Stoqn", "Georgiev", 5)
            };

            List<Teacher> teachers11A = new List<Teacher>()
            {
                new Teacher("Petar", "Georgiev", new List<Discipline>()
                {
                    new Discipline("Phisycs", 12, 6, "Raquired"),
                    new Discipline("Mathematics", 12 , 6, "Raquired")
                }, "Alviable only in the mornings!"),
                new Teacher("Ivan", "Petrov", new List<Discipline>()
                {
                    new Discipline("Economics", 12, 6, "Optional"),
                    new Discipline("Mathematics", 12 , 6, "Raquired")
                }, "Alviable only afternoon!"),
                new Teacher("Stoian", "Toshev", new List<Discipline>(){ new Discipline("Phisycs", 10, 10, "Raquired") }, "")
            };

            school.AddSchoolClass(new SchoolClass("11A", students11A, teachers11A, "Just comment!"));
            Console.WriteLine(school);
        }
    }
}
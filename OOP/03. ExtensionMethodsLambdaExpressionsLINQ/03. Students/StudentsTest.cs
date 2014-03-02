using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Students
{
    class StudentsTest
    {
        static void Main(string[] args)
        {
            // Create a list of students
            List<Students> students = new List<Students>()
            {
                new Students("Иван", "Иванич", 17, "32535065", "0888123450", "aaaaa@abv.bg", new List<int>(){6, 6, 5, 4, 5, 6}, new Group("Mathematics", 2)),
                new Students("Пешо", "Петров", 18, "32535066", "0888123451", "eeee@dir.com", new List<int>(){3, 6, 2, 4, 2, 5}, new Group("Physics", 1)),
                new Students("Пешо", "Попов", 24, "32535057", "02123452", "bbbbbbbb@abv.bg", new List<int>(){6, 4, 5, 6, 5, 3}, new Group("Mathematics", 2)),
                new Students("Гошо", "Стоянов", 20, "32535078", "02123453", "cccccc@abv.bg", new List<int>(){5, 4, 5, 4, 4, 3}, new Group("Chemistry", 3)),
                new Students("Тошо", "Тонев", 25, "32535069", "0888123454", "ddddd@mail.bg", new List<int>(){6, 4, 3, 6, 5, 4}, new Group("Mathematics", 2)),
            };

            // Task 3
            var collection = GetByName(students);
            Print(collection, "Students whose first name is before its last name alphabetically:");

            // Task 4
            collection = GetByAge(students, 18, 24);
            Print(collection, "Students with age between 18 and 24:");

            // Task 5
            collection = SortByFirstLastExts(students);
            Print(collection, "Sorted students by first name and last name in descending order (Extention):");

            collection = SortByFirstLastLinq(students);
            Print(collection, "Sorted students by first name and last name in descending order (LINQ):");

            // Task 9
            collection = GetByGroupOrderByNameLinq(students, 2);
            Print(collection, "Students in Group #2 ordered by first name (LINQ):");

            // Task 10
            collection = GetByGroupOrderByNameExts(students, 2);
            Print(collection, "Students in Group #2 ordered by first name (Extention):");

            // Task 11
            collection = GetByEmailIn(students, "@abv.bg");
            Print(collection, "Students with email in 'abv.bg':");

            // Task 12
            collection = GetByPhoneIn(students, "02");
            Print(collection, "Students with telephone number in 'Sofia':");

            // Task 13
            var collectionAnonymous = GetByMarkLinq(students, 6);
            Print(collectionAnonymous, "Students with at least one mark '6':");

            // Task 14
            collectionAnonymous = GetByMarkExts(students, 2, 2);
            Print(collectionAnonymous, "Students with at least tow mark '2':");

            // Task 15
            collection = GetByYearEnrolled(students, "06");
            Print(collection, "Students that enrolled in '2006':");

            // Task 16
            collection = GetByDepartmentName(students, "Mathematics");
            Print(collection, "Students from 'Mathematics' department:");

            // Task 17
            collection = new List<Students>() { GetByNameLength(students) };
            Print(collection, "Student with longest family name:");

            // Task 18
            var groups = GetGroupedByGroupName(students);
            foreach (var currentGroup in groups)
            {
                Print(currentGroup, "Students from " + currentGroup.Key + ":");
            }
        }

        // Print students collection
        private static void Print<T>(IEnumerable<T> collection, string str)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (var student in collection)
            {
                if (collection is IEnumerable<Students>)
                {
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("{0}, Marks: {{ {1} }}", ((dynamic)student).FullName, string.Join(", ", ((dynamic)student).Marks));
                }
            }

            Console.WriteLine();
        }

        // 3. Write a method that from a given array of students finds all students
        //    whose first name is before its last name alphabetically. Use LINQ
        //    query operators.
        public static IEnumerable<Students> GetByName(IEnumerable<Students> students)
        {
            return from student in students
                   where student.FirstName.CompareTo(student.LastName) < 0
                   select student;
        }

        // 4. Write a LINQ query that finds the first name and last name of all
        //    students with age between 18 and 24.
        public static IEnumerable<Students> GetByAge(IEnumerable<Students> students, int ageStart, int ageEnd)
        {
            return from student in students
                   where student.Age >= ageStart && student.Age <= ageEnd
                   select student;
        }

        // 5. Using the extension methods OrderBy() and ThenBy() with lambda
        //    expressions sort the students by first name and last name in
        //    descending order. Rewrite the same with LINQ.
        private static IEnumerable<Students> SortByFirstLastExts(IEnumerable<Students> students)
        {
            return students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
        }

        private static IEnumerable<Students> SortByFirstLastLinq(IEnumerable<Students> students)
        {
            return from student in students
                   orderby student.FirstName descending, student.LastName descending
                   select student;
        }

        // 9. Create a class student with properties FirstName, LastName, FN,
        //    Tel, Email, Marks (a List<int>), GroupNumber. Create a List<Student>
        //    with sample students. Select only the students that are from group
        //    number 2. Use LINQ query. Order the students by FirstName.
        public static IEnumerable<Students> GetByGroupOrderByNameLinq(IEnumerable<Students> students, int groupNumb)
        {
            return from student in students
                   where student.StudentGroup.GroupNumber == groupNumb
                   orderby student.FirstName
                   select student;
        }

        // 10. Implement the previous using the same query expressed with
        //     extension methods.
        public static IEnumerable<Students> GetByGroupOrderByNameExts(IEnumerable<Students> students, int groupNumb)
        {
            return students.Where(x => x.StudentGroup.GroupNumber == groupNumb).OrderBy(x => x.FirstName);
        }

        // 11. Extract all students that have email in abv.bg. Use string
        //     methods and LINQ.
        private static IEnumerable<Students> GetByEmailIn(IEnumerable<Students> students, string str)
        {
            return from student in students
                   where student.Email.EndsWith(str)
                   select student;
        }

        // 12. Extract all students with phones in Sofia. Use LINQ.
        private static IEnumerable<Students> GetByPhoneIn(IEnumerable<Students> students, string str)
        {
            return from student in students
                   where student.Tel.StartsWith(str)
                   select student;
        }

        // 13. Select all students that have at least one mark
        //     Excellent (6) into a new anonymous class that has
        //     properties – FullName and Marks. Use LINQ.
        private static IEnumerable<Object> GetByMarkLinq(IEnumerable<Students> students, int mark)
        {
            return from student in students
                   where student.Marks.Contains(mark)
                   select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };
        }

        // 14. Write down a similar program that extracts the students
        //     with exactly  two marks "2". Use extension methods.
        private static IEnumerable<Object> GetByMarkExts(IEnumerable<Students> students, int mark, int count)
        {
            return students.Where(x => (x.Marks.Where(y => y == mark).Count() == count)).Select(z => new { FullName = z.FirstName + " " + z.LastName, Marks = z.Marks });
        }

        // 15. Extract all Marks of the students that enrolled in 2006. (The
        //     students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        private static IEnumerable<Students> GetByYearEnrolled(IEnumerable<Students> students, string year)
        {
            return from student in students
                   where student.FacNumb.Substring(5, 2) == year
                   select student;
        }

        // 16. Create a class Group with properties GroupNumber and
        //     DepartmentName. Introduce a property Group in the Student
        //     class. Extract all students from "Mathematics" department.
        //     Use the Join operator.
        private static IEnumerable<Students> GetByDepartmentName(IEnumerable<Students> students, string departmentName)
        {
            // The task is wrong it does not need a JOINT. The next declaration is just to have a joint :)
            var groups = new List<Group>() { new Group("Mathematics", 2) };

            return from student in students
                   join studentGroup in groups on student.StudentGroup.DepartmentName equals studentGroup.DepartmentName
                   where studentGroup.DepartmentName == departmentName
                   select student;
        }

        // 17. Write a program to return the string with maximum length
        //     from an array of strings. Use LINQ.
        private static Students GetByNameLength(IEnumerable<Students> students)
        {
            return (from student in students
                    orderby student.LastName
                    select student).First();
        }

        // 18. Create a program that extracts all students grouped by GroupName 
        //     and then prints them to the console. Use LINQ.
        private static IEnumerable<IGrouping<string, Students>> GetGroupedByGroupName(IEnumerable<Students> students)
        {
            return from student in students
                   group student by student.StudentGroup.DepartmentName into groups
                   orderby groups.Key
                   select groups;
        }
    }
}
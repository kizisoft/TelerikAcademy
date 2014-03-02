// 1. Define a class Student, which contains data about a student – first,
//    middle and last name, SSN, permanent address, mobile phone e-mail,
//    course, specialty, university, faculty. Use an enumeration for the
//    specialties, universities and faculties. Override the standard methods,
//    inherited by  System.Object: Equals(), ToString(), GetHashCode() and
//    operators == and !=.
//
// 2. Add implementations of the ICloneable interface. The Clone() method
//    should deeply copy all object's fields into a new object of type Student.
//
// 3. Implement the  IComparable<Student> interface to compare students by
//    names (as first criteria, in lexicographic order) and by social security
//    number (as second criteria, in increasing order).

namespace _01.Student
{
    using System;
    using System.Collections.Generic;

    public class StudentTest
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>() 
            {
                new Student("Ivan", "Ivanov", "Ivanov", "87654321"),
                new Student("Dragan", "Todotov", "Petrov", "21324354"),
                new Student("Petar", "Iliev", "Georgiev", "54433221"),
                new Student("Gosho", "Dimitrov", "Stoev", "65674543"), 
                new Student("Misho", "Ivanov", "Petrov", "87125423"),
                new Student("Ivan", "Ivanov", "Ivanov", "12345678") 
            };

            Console.WriteLine("List of students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            var cloneStudent = students[0].Clone();
            Console.WriteLine();
            Console.WriteLine("Cloned student: {0}", cloneStudent);

            Console.WriteLine();
            Console.WriteLine("Compare first and last students: {0}", students[0].CompareTo(students[5]));
            Console.WriteLine("  result       means");
            Console.WriteLine("   < 0   : first < last");
            Console.WriteLine("   > 0   : last > first");
            Console.WriteLine("   = 0   : first == last");

            students.Sort();
            Console.WriteLine();
            Console.WriteLine("List of sorted students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
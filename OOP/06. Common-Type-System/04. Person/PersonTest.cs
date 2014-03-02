// 4. Create a class Person with two fields – name and age. Age can be
//    left unspecified (may contain null value. Override ToString() to
//    display the information of a person and if age is not specified – 
//    to say so. Write a program to test this functionality.

namespace _04.Person
{
    using System;

    public class PersonTest
    {
        public static void Main(string[] args)
        {
            var person = new Person("Haralambi Stamatov Prokopiev", 35);
            Console.WriteLine("Here is the person:");
            Console.WriteLine(person);
            Console.WriteLine();

            person = new Person("Haralambi Stamatov Prokopiev");
            Console.WriteLine("Here is the same person without age defined:");
            Console.WriteLine(person);
        }
    }
}
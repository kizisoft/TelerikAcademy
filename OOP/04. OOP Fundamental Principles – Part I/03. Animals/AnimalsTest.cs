// 3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful
//    constructors and methods. Dogs, frogs and cats are Animals. All animals
//    can produce sound (specified by the ISound interface). Kittens and
//    tomcats are cats. All animals are described by age, name and sex. Kittens
//    can be only female and tomcats can be only male. Each animal produces a
//    specific sound. Create arrays of different kinds of animals and calculate
//    the average age of each kind of animal using a static method (you may use LINQ).

namespace _03.Animals
{
    using System;
    using System.Collections.Generic;

    public class AnimalsTest
    {
        public static void Main(string[] args)
        {
            // Store animals in the list
            List<Animal> zoo = new List<Animal>();
            zoo.Add(new Cat("Kotio", 3, Sex.Male));
            zoo.Add(new Cat("Pisa", 6, Sex.Female));
            zoo.Add(new Cat("Maca", 5, Sex.Female));
            zoo.Add(new Tomcat("Pisan", 9));
            zoo.Add(new Tomcat("Kotan", 8));
            zoo.Add(new Tomcat("Kotache", 4));
            zoo.Add(new Kitten("Pisanche", 1));
            zoo.Add(new Kitten("Kotanche", 2));
            zoo.Add(new Kitten("Marrrcho", 3));
            zoo.Add(new Dog("Sharo", 7, Sex.Male));
            zoo.Add(new Dog("Vihar", 2, Sex.Female));
            zoo.Add(new Dog("Balkan", 6, Sex.Male));
            zoo.Add(new Frog("Gold", 1, Sex.Female));
            zoo.Add(new Frog("Silver", 4, Sex.Male));
            zoo.Add(new Frog("Bronze", 5, Sex.Female));

            // Print all animals
            Console.WriteLine("Zoo:");
            foreach (var animal in zoo)
            {
                Console.WriteLine(animal);
                animal.PlaySound();
                Console.WriteLine();
            }

            // Print average age of given type of animal
            Console.WriteLine("Average Cat's age = {0} years", Animal.Average(zoo, typeof(Cat)));
            Console.WriteLine("Average Tomcat's age = {0} years", Animal.Average(zoo, typeof(Tomcat)));
            Console.WriteLine("Average Kitten's age = {0} years", Animal.Average(zoo, typeof(Kitten)));
            Console.WriteLine("Average Dog's age = {0} years", Animal.Average(zoo, typeof(Dog)));
            Console.WriteLine("Average Frog's age = {0} years", Animal.Average(zoo, typeof(Frog)));
        }
    }
}
namespace _03.Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, int age, Sex animalSex)
        {
            this.Name = name;
            this.Age = age;
            this.AnimalSex = animalSex;
        }

        // Play a specific sound depending of animal
        public override void PlaySound()
        {
            Console.WriteLine("Uaau-Uauu! Bau!");
        }
    }
}
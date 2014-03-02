﻿namespace _03.Animals
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, int age, Sex animalSex)
        {
            this.Name = name;
            this.Age = age;
            this.AnimalSex = animalSex;
        }

        // Play a specific sound depending of animal
        public override void PlaySound()
        {
            Console.WriteLine("Maaaauuuuu!");
        }
    }
}
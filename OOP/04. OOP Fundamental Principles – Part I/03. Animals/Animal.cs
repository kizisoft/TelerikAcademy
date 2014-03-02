namespace _03.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Abstract class for all animals
    // Inplement ISound interface to define sound for each animal
    public abstract class Animal : ISound
    {
        public int Age { get; protected set; }

        public string Name { get; protected set; }

        public string AnimalSex { get; protected set; }

        // Calculate average age of animals from the list
        public static double Average(IList<Animal> zoo, Type type)
        {
            return (from animal in zoo
                    where animal.GetType() == type
                    select animal.Age).Average();
        }

        // Play a specific sound depending of animal
        public abstract void PlaySound();

        public override string ToString()
        {
            return string.Format("[{0}]: I'm {1}. My sex is {2}. I'm {3} year(s) old.", this.GetType().Name, this.Name, this.AnimalSex, this.Age);
        }
    }
}
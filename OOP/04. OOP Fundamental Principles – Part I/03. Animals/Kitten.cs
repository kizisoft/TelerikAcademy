namespace _03.Animals
{
    public class Kitten : Cat
    {
        // Create only female Cats
        public Kitten(string name, int age)
            : base(name, age, Sex.Female)
        {
        }
    }
}
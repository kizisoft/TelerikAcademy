namespace _03.Animals
{
    public class Tomcat : Cat
    {
        // Create only male Cats
        public Tomcat(string name, int age)
            : base(name, age, Sex.Male)
        {
        }
    }
}
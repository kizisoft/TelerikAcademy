namespace _04.Person
{
    public class Person
    {
        public Person(string fullName, int? age = null)
        {
            this.Age = age;
            this.FullName = fullName;
        }

        public int? Age { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.FullName == null ? "undefined" : this.FullName, this.Age == null ? "undefined" : this.Age.ToString());
        }
    }
}
namespace _02.Humans
{
    // Student class derived from Human 
    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        // Grade
        public int Grade { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-20} Grade: {1}", base.ToString(), this.Grade);
        }
    }
}
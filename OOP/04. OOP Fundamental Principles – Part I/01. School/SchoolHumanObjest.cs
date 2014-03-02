namespace _01.School
{
    using System;

    // Abstract class that is inherited by all human objects
    public abstract class SchoolHumanObjest : SchoolObject
    {
        public SchoolHumanObjest(string name, string lastName, string comments = "")
            : base(name, comments)
        {
            this.LastName = lastName;
        }

        public string LastName { get; private set; }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("{0} {1}{2}{3}", this.Name, this.LastName, Environment.NewLine, this.Comments);
        }
    }
}
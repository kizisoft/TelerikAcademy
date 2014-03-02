namespace _01.School
{
    using System;
    using System.Collections.Generic;

    // Base abstract school class
    public abstract class SchoolObject
    {
        public SchoolObject(string name, string comments)
        {
            this.Name = name;
            this.Comments = comments;
        }

        public string Name { get; private set; }

        public string Comments { get; private set; }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("{0}{1}{2}", this.Name, Environment.NewLine, this.Comments);
        }
    }
}
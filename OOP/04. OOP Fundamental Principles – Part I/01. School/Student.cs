namespace _01.School
{
    using System;

    public class Student : SchoolHumanObjest
    {
        public Student(string name, string lastName, int classNumb, string comments = null)
            : base(name, lastName, comments)
        {
            this.ClassNumb = classNumb;
        }

        public int ClassNumb { get; private set; }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("[STUDENT]:{0}{1}{0}#{2}{0}", Environment.NewLine, base.ToString(), this.ClassNumb);
        }
    }
}
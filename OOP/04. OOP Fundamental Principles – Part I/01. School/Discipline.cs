namespace _01.School
{
    using System;

    public class Discipline : SchoolNoneHumanObject
    {
        public Discipline(string name, int numbLectures, int numbExercisses, string comments = null)
            : base(name, comments)
        {
            this.NumbLectures = numbLectures;
            this.NumbExercises = numbExercisses;
        }

        public int NumbLectures { get; private set; }

        public int NumbExercises { get; private set; }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("[DISCIPLINE]:{0}{1}{0}Lectures #{3}; Exercises #{3}{0}", Environment.NewLine, base.ToString(), this.NumbLectures, this.NumbExercises);
        }
    }
}
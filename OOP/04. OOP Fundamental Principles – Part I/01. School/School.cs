namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class School : SchoolObject
    {
        private List<SchoolClass> schoolClasses;

        public School(string name, string comments = null, List<SchoolClass> schoolClasses = null)
            : base(name, comments)
        {
            if (schoolClasses != null)
            {
                this.SchoolClasses = schoolClasses;
            }
            else
            {
                this.SchoolClasses = new List<SchoolClass>();
            }
        }

        public List<SchoolClass> SchoolClasses
        {
            get { return new List<SchoolClass>(this.schoolClasses); }
            private set { this.schoolClasses = value; }
        }

        // Add SchoolClass to the list
        public void AddSchoolClass(SchoolClass schoolClass)
        {
            if (schoolClass == null)
            {
                throw new ArgumentNullException("School parameter is Null!");
            }

            this.schoolClasses.Add(schoolClass);
        }

        // Remove SchoolClass from the list
        public bool RemoveSchoolClass(SchoolClass schoolClass)
        {
            if (schoolClass == null)
            {
                throw new ArgumentNullException("School parameter is Null!");
            }

            if (!this.schoolClasses.Contains(schoolClass))
            {
                return false;
            }

            return this.schoolClasses.Remove(schoolClass);
        }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("[SCHOOL]:{0}{1}{0}{0}{2}", Environment.NewLine, base.ToString(), string.Join(Environment.NewLine, this.schoolClasses));
        }
    }
}
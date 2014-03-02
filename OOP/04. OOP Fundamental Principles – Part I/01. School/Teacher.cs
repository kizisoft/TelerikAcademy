namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : SchoolHumanObjest
    {
        private List<Discipline> disciplinesList;

        public Teacher(string name, string lastName, List<Discipline> disciplinesSet = null, string comments = null)
            : base(name, lastName, comments)
        {
            if (disciplinesSet != null)
            {
                this.DisciplinesList = disciplinesSet;
            }
            else
            {
                this.disciplinesList = new List<Discipline>();
            }
        }

        public List<Discipline> DisciplinesList
        {
            get { return new List<Discipline>(this.disciplinesList); }
            private set { this.disciplinesList = value; }
        }

        // Add Discipline in the list
        public void AddDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException("Discipline parameter is Null!");
            }

            this.disciplinesList.Add(discipline);
        }

        // Remove Discipline from the list
        public bool RemoveDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException("Discipline parameter is Null!");
            }

            if (!this.disciplinesList.Contains(discipline))
            {
                return false;
            }

            return this.disciplinesList.Remove(discipline);
        }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("[TEACHER]:{0}{1}{0}{0}{2}", Environment.NewLine, base.ToString(), string.Join(Environment.NewLine, this.disciplinesList));
        }
    }
}
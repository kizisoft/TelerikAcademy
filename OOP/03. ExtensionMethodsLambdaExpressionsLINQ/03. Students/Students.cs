using System;
using System.Collections.Generic;

namespace _03.Students
{
    public class Students
    {
        // Private Students fields
        private string firstName;
        private string lastName;
        private string facNumb;
        private string tel;
        private string email;
        private List<int> marks;
        private int age;
        private Group studentGroup;

        public Students(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Students(string firstName, string lastName, int age, string facNumb, string tel, string email, List<int> marks, Group studentGroup)
            : this(firstName, lastName, age)
        {
            this.FacNumb = facNumb;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            if (studentGroup == null)
            {
                throw new ArgumentNullException("Student Group must not be NULL!");
            }
            this.StudentGroup = studentGroup;
        }

        // Public Students fields
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FacNumb
        {
            get { return facNumb; }
            set { facNumb = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public List<int> Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Group StudentGroup
        {
            get { return studentGroup; }
            set { studentGroup = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} is {2} ages{3}", FirstName, LastName, Age, Environment.NewLine) +
                string.Format("FacNum #{0}, Group '{1}' #{2}, Marks {{ {3} }}{4}", FacNumb, StudentGroup.DepartmentName, StudentGroup.GroupNumber, string.Join(", ", Marks), Environment.NewLine) +
                string.Format("Tel: {0}, Email: {1}{2}", Tel, Email, Environment.NewLine);
        }

    }
}
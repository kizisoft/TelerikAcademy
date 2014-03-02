namespace _01.Student
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        // Public constructors
        public Student(string firstName, string middleName, string lastName, string sSN, string permanentAddress, string mobilePhone, string email, University university, Faculty faculty, Specialty specialty, int? course)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = sSN;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.Course = course;
        }

        public Student(string firstName, string middleName, string lastName, string sSN)
            : this(firstName, middleName, lastName, sSN, null, null, null, University.Unspecified, Faculty.Unspecified, Specialty.Unspecified, null)
        {
        }

        // Public properties
        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public string SSN { get; private set; }

        public int? Course { get; private set; }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }

        public string Email { get; private set; }

        public University University { get; private set; }

        public Specialty Specialty { get; private set; }

        public Faculty Faculty { get; private set; }

        // Predefined operators
        public static bool operator ==(Student studentA, Student studentB)
        {
            return Student.Equals(studentA, studentB);
        }

        public static bool operator !=(Student studentA, Student studentB)
        {
            return !Student.Equals(studentA, studentB);
        }

        // Override methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if ((object)student == null)
            {
                return false;
            }

            return this.SSN == student.SSN &&
                   this.LastName == student.LastName &&
                   this.MiddleName == student.MiddleName &&
                   this.FirstName == student.FirstName;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}, SSN: {3}", this.FirstName, this.MiddleName, this.LastName, this.SSN);
        }

        // Implement ICloneable interface
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, this.MobilePhone, this.Email, this.University, this.Faculty, this.Specialty, this.Course);
        }

        // Implement IComparable interface
        public int CompareTo(Student other)
        {
            int res = string.Compare(this.FirstName + this.MiddleName + this.LastName, other.FirstName + other.MiddleName + other.LastName);
            if (res == 0)
            {
                return string.Compare(this.SSN, other.SSN);
            }

            return res;
        }
    }
}
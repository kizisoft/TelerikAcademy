namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class SchoolClass : SchoolNoneHumanObject
    {
        private List<Student> studentList;
        private List<Teacher> teacherList;

        public SchoolClass(string name, List<Student> studentList = null, List<Teacher> teacherList = null, string comments = null)
            : base(name, comments)
        {
            if (studentList != null)
            {
                this.StudentList = studentList;
            }
            else
            {
                this.studentList = new List<Student>();
            }

            if (teacherList != null)
            {
                this.TeacherList = teacherList;
            }
            else
            {
                this.teacherList = new List<Teacher>();
            }
        }

        public List<Student> StudentList
        {
            get { return new List<Student>(this.studentList); }
            private set { this.studentList = value; }
        }

        public List<Teacher> TeacherList
        {
            get { return new List<Teacher>(this.teacherList); }
            private set { this.teacherList = value; }
        }

        // Add Student in the students list
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("School parameter is Null!");
            }

            this.studentList.Add(student);
        }

        // Remove Student from the students list
        public bool RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("School parameter is Null!");
            }

            if (!this.studentList.Contains(student))
            {
                return false;
            }

            return this.studentList.Remove(student);
        }

        // Add Teacher in the list
        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher parameter is Null!");
            }

            this.teacherList.Add(teacher);
        }

        // Remove Teacher from the list
        public bool RemoveTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher parameter is Null!");
            }

            if (!this.teacherList.Contains(teacher))
            {
                return false;
            }

            return this.teacherList.Remove(teacher);
        }

        // Return the string representation of object
        public override string ToString()
        {
            return string.Format("[SCHOOL CLASS]:{0}{1}{0}{0}{2}{0}{3}", Environment.NewLine, base.ToString(), string.Join(Environment.NewLine, this.studentList), string.Join(Environment.NewLine, this.teacherList));
        }
    }
}
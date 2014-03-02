using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students
{
    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(string departmentName, int groupNumber)
        {
            this.DepartmentName = departmentName;
            this.GroupNumber = groupNumber;
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

    }
}
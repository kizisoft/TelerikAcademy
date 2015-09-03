namespace SearchCarsWebForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Extra
    {
        public Extra(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
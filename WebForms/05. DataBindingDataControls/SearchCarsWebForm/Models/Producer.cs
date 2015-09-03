namespace SearchCarsWebForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Producer
    {
        public Producer(string name, List<Model> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public string Name { get; set; }

        public List<Model> Models { get; set; }
    }
}
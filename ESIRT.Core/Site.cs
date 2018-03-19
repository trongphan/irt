using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public class Site
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Test { get; set; }

        private int _Abc;

        private DateTime _createdDate; 

        public Site(NewSite site)
        {
            Name = site.Name;
            _createdDate = DateTime.UtcNow;
        }

        IEnumerable<Subject> Subjects;
    }
}

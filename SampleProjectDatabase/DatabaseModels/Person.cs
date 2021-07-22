using SampleProjectDatabase.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectDatabase.DatabaseModels
{
    public class Person
    {
        public Person()
        {
            Company = new HashSet<Company>();
        }
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Company> Company { get; set; }

    }
}

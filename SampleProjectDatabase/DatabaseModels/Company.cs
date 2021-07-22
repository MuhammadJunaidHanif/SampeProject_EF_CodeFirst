using SampleProjectDatabase.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectDatabase.DatabaseContext
{
   public  class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CEO { get; set; }
        public virtual Person Person { get; set; }
    }
}

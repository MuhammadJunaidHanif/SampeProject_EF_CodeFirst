using Microsoft.EntityFrameworkCore;
using SampleProjectDatabase.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectDatabase.DataSeeds
{
    public static class Seeds
    {
        public static void PersonSeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person 
                { 
                    Id = 1,
                    FName = "Muhammad ",
                    LName="Junaid",
                    Email="syedjunaidhanif@gmail.com",
                    Address="Lahore",
                    Password= "tylqZKJAuUrW94/8GfoItxs282CnvA/URdTkrVXAMl4="//Admin123
                });
        }
    }
}

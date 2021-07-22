using Microsoft.EntityFrameworkCore;
using SampleProject.Repository.Interfaces;
using SampleProjectDatabase.DatabaseContext;
using SampleProjectDatabase.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Implimentations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbSet<Person> _person;
        private readonly CompanyManagementDbContext _db;

        public PersonRepository(CompanyManagementDbContext db)
        {
            _db = db;
            _person = _db.Set<Person>();
        }

        public async Task<bool> Create(Person person)
        {
             await _person.AddAsync(person);
            _db.SaveChanges();
            return true;
        }

        public async Task<Person> GetUserByEmail(string email)
        {
           return await _person
                .Where(u=>u.Email.ToLower()==email.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}

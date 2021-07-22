using SampleProjectDatabase.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> Create(Person person);
        Task<Person> GetUserByEmail(string email);
    }
}

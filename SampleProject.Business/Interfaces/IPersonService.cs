using SampleProjectModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Interfaces
{
    public interface IPersonService
    {
        Task<bool> CreateUser(SignupDto input);
        Task<PersonVm> Login(string email, string password);
    }
}

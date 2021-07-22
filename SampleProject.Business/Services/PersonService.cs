using SampleProject.Business.Exceptions;
using SampleProject.Business.Interfaces;
using SampleProject.Repository.Interfaces;
using SampleProjectDatabase.DatabaseModels;
using SampleProjectModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> CreateUser(SignupDto input)
        {
            var person = new Person
            {
                FName = input.FName,
                LName = input.LName,
                Address = input.Address,
                Email = input.Email,
                Phone = input.Phone,
                Password = EncryptionDecryptionService.Encryption(input.Password)
            };
            return await _personRepository.Create(person);
        }

        public async Task<PersonVm> Login(string email, string password)
        {
            var person = await _personRepository.GetUserByEmail(email);
            
            if (person != null)
            {
                var passwod = EncryptionDecryptionService.Encryption(password);
                if (passwod == person.Password)
                {
                    return new PersonVm 
                    {
                        Id=person.Id,
                        FName = person.FName,
                        LName = person.LName,
                        Address = person.Address,
                        Email = person.Email,
                        Phone = person.Phone,
                    };

                }
                else
                {
                    throw new UnauthorizedException("Incorrect Password");
                }
            }

            else
            {
                throw new UnauthorizedException("Incorrect Email");
            }
        }
    }
}

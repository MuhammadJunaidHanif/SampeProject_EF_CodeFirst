using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Interfaces;
using SampleProjectModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_CodefFirst_SampleProject.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost("SignUp")]
        public async Task<bool> SignUp(SignupDto input)
        {
            return await _personService.CreateUser(input);
        }

        [HttpGet("signIn")]
        public async Task<PersonVm> Login(string email,string password)
        {
            return await _personService.Login(email, password);
        }
    }
}

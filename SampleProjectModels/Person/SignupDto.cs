using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectModels.Person
{
    public class SignupDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
    public class SignupValidator : AbstractValidator<SignupDto>
    {
        public SignupValidator()
        {
            RuleFor(x => x.FName).NotNull().MinimumLength(3);
            RuleFor(x => x.LName).NotNull().MinimumLength(3);
        }
    }
}

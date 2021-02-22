using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotNull();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotNull();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(6);
            RuleFor(p => p.Email).Must(MailCheck).When(p=>p.Email != null).WithMessage("IsValid Mail");
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).NotNull();
        }

        private bool MailCheck(string arg)
        {
            return arg.Contains("@");
        }
    }
}

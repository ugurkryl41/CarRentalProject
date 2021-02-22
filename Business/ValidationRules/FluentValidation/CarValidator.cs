using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("Description must be at least 2 characters");
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Description).NotNull();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100).When(p => p.BrandId == 1);
            RuleFor(p => p.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(p => p.ModelYear).NotEmpty();            
            RuleFor(p => p.BrandId).GreaterThan(0);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).GreaterThan(0);
            RuleFor(p => p.ColorId).NotEmpty();

            RuleFor(p => p.Description).Must(StartWithA).When(p=>p.Description!=null).WithMessage("Description Must start with the letter A");           
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}


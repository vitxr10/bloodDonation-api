using BloodDonation.Application.Commands.CreateDonation;
using BloodDonation.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Validators
{
    public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationCommandValidator()
        {
            RuleFor(dn => dn.AmountInML)
               .GreaterThan(420)
               .LessThanOrEqualTo(470)
               .WithMessage("A quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml");
        }
    }
}

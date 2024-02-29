using BloodDonation.Application.Commands.UpdateDonor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Validators
{
    public class UpdateDonorCommandValidator : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorCommandValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(d => d.Weight)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}

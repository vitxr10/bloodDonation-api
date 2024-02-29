using BloodDonation.Application.Commands.CreateDonor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Validators
{
    public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorCommandValidator()
        {
            RuleFor(d => d.FullName)
                .NotEmpty()
                .NotNull();

            RuleFor(d => d.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(d => d.BirthDate)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(d => d.Gender)
                .IsInEnum();

            RuleFor(d => d.Weight)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(d => d.BloodType)
                .IsInEnum();

            RuleFor(d => d.RHFactor)
                .IsInEnum();

            RuleFor(d => d.Address.Neighborhood)
                .NotEmpty()
                .NotNull();

            RuleFor(d => d.Address.State)
                .NotEmpty()
                .NotNull();

            RuleFor(d => d.Address.City)
                .NotEmpty()
                .NotNull();

            RuleFor(d => d.Address.ZipCode)
                .NotEmpty()
                .NotNull();
        }
    }
}

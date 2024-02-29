using BloodDonation.Application.Commands.CreateStock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Validators
{
    public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
    {
        public CreateStockCommandValidator()
        {
            RuleFor(s => s.BloodType)
                .IsInEnum();

            RuleFor(s => s.RHFactor)
                .IsInEnum();
        }
    }
}

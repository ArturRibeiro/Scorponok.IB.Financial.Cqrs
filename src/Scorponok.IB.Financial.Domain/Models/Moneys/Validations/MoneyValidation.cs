using System;
using FluentValidation;

namespace Scorponok.IB.Financial.Domain.Models.Moneys.Validations
{
    public class MoneyValidation : AbstractValidator<Money>
    {
        public MoneyValidation()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.ReleaseDateOf)
                .NotNull()
                .GreaterThan(DateTime.MinValue);
            RuleFor(x => x.ReleaseDateOf)
                .NotNull()
                .LessThan(DateTime.MaxValue);
            RuleFor(x => x.Value)
                .NotNull()
                .GreaterThan(0);

            RuleFor(customer => customer.TypeInput)
                .NotNull()
                .SetValidator(new LaunchValidation());
        }
    }
}
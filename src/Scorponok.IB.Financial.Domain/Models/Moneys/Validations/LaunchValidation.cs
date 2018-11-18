using FluentValidation;

namespace Scorponok.IB.Financial.Domain.Models.Moneys.Validations
{
    public class LaunchValidation : AbstractValidator<Launch>
    {
        public LaunchValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
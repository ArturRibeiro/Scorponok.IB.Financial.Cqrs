using FluentValidation.Results;
using Scorponok.IB.Financial.Domain.Core.Models;
using Scorponok.IB.Financial.Domain.Models.Budgets.Validations;

namespace Scorponok.IB.Financial.Domain.Models.Budgets
{
    public class Budget : Entity<int>
    {
        public override ValidationResult Validate() => new BudgetValidation().Validate(this);
    }
}
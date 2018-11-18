using System;
using FluentValidation.Results;
using Scorponok.IB.Financial.Domain.Core.Models;
using Scorponok.IB.Financial.Domain.Models.Moneys.Validations;

namespace Scorponok.IB.Financial.Domain.Models.Moneys
{
    public class Money : Entity<int>
    {
        #region Properties

        public Guid PersonId { get; private set; }

        public DateTime ReleaseDateOf { get; private set; }

        public decimal Value { get; private set; } = 0;

        public Launch TypeInput { get; set; } = null;

        #endregion

        public override ValidationResult Validate() 
            => new MoneyValidation().Validate(this);

        #region Factory
        public static class Factory
        {
            public static Money Create(Launch typeInput, decimal inputValue, DateTime releaseDateOf, Guid personId)
                => new Money()
                {
                    TypeInput = typeInput,
                    Value = inputValue,
                    ReleaseDateOf = releaseDateOf,
                    PersonId = personId
                };
        }
        #endregion
    }
}

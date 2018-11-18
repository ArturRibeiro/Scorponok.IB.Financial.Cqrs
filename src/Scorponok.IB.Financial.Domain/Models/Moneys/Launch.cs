using FluentValidation.Results;
using Scorponok.IB.Financial.Domain.Core.Models;
using Scorponok.IB.Financial.Domain.Models.Moneys.Validations;

namespace Scorponok.IB.Financial.Domain.Models.Moneys
{
    public class Launch : Entity<int>
    {
        public TypeLaunch TypeLaunch { get; private set; }

        public override ValidationResult Validate() => new LaunchValidation().Validate(this);

        #region Factory
        public static class Factory
        {
            public static Launch Create(int id, TypeLaunch typeLaunch)
                => new Launch() { Id = id, TypeLaunch = typeLaunch };
        }
        #endregion
    }
}
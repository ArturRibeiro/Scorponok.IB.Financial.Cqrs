using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Financial.Domain.Models.Moneys;

namespace Scorponok.IB.Unit.Tests.Models
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void Create_a_new_input_with_personId_not_found()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 1, DateTime.Now, Guid.Empty);

            money.IsValid.Should().BeFalse();
            var result = money.Validate();
            result.Errors.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void Create_a_new_input_with_release_date_of_with_date_min_value()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 1, DateTime.MinValue, Guid.NewGuid());

            money.IsValid.Should().BeFalse();
            var result = money.Validate();
            result.Errors.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void Create_a_new_input_with_release_date_of_with_date_max_value()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 1, DateTime.MaxValue, Guid.NewGuid());

            money.IsValid.Should().BeFalse();
            var result = money.Validate();
            result.Errors.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void Create_a_new_input_with_value_equals_zero()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 0, DateTime.Now, Guid.NewGuid());

            money.IsValid.Should().BeFalse();
            var result = money.Validate();
            result.Errors.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void Create_a_new_input_with_value_negative()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), -4, DateTime.Now, Guid.NewGuid());

            money.IsValid.Should().BeFalse();
            var result = money.Validate();
            result.Errors.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void Create_a_new_input_with_success()
        {
            Money money = Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 500, DateTime.Now, Guid.NewGuid());

            money.IsValid.Should().BeTrue();
            var result = money.Validate();
            result.Errors.Should()
                .BeEmpty();
        }

        [Test]
        public void Create_multiple_input_and_add_the_total_value()
        {
            var inputs = new[]
            {
                Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 1, DateTime.Now, Guid.NewGuid()),
                Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 2, DateTime.Now, Guid.NewGuid()),
                Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 3, DateTime.Now, Guid.NewGuid()),
                Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 4, DateTime.Now, Guid.NewGuid()),
                Money.Factory.Create(Launch.Factory.Create(1, TypeLaunch.Input), 5, DateTime.Now, Guid.NewGuid()),
            };

            inputs.Any(x => x.IsValid).Should().BeTrue();
            var result = inputs.Any(x => x.Validate().Errors.Count > 0)
                .Should()
                .BeFalse();
            inputs.Sum(s => s.Value).Should().Be(15);
        }
    }
}
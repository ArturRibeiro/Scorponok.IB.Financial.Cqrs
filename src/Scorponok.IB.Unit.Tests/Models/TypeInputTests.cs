using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Financial.Domain.Models.Moneys;

namespace Scorponok.IB.Unit.Tests.Models
{
    [TestFixture]
    public class TypeInputTests
    {
        [Test]
        public void Create_a_type_input_with_id_valid()
        {
            var result =  Launch.Factory.Create(1, TypeLaunch.Input).Validate();

            result.IsValid.Should().BeTrue();
            result.Errors.Should()
                .BeEmpty();
        }

        [Test]
        public void Create_a_type_input_with_id_negative()
        {
            var result = Launch.Factory.Create(-1, TypeLaunch.Input).Validate();

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .HaveCount(1);
        }

        [Test]
        public void Create_a_type_output_with_id_valid()
        {
            var result = Launch.Factory.Create(1, TypeLaunch.Output).Validate();

            result.IsValid.Should().BeTrue();
            result.Errors.Should()
                .BeEmpty();
        }

        [Test]
        public void Create_a_type_output_with_id_negative()
        {
            var result = Launch.Factory.Create(-1, TypeLaunch.Output).Validate();

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .HaveCount(1);
        }
    }
}
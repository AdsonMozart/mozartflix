using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using MozartFlix.Catalog.Domain.Validation;
using FluentAssertions;
using MozartFlix.Catalog.Domain.Exceptions;

namespace MozartFlix.Catalog.UnitTests.Domain.Validation
{
    public class DomainValidationTest
    {
        private Faker Faker { get; set; } = new Faker();

        // Não ser null
        [Fact(DisplayName = nameof(NotNullOk))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullOk()
        {
            var value = Faker.Commerce.ProductName();
            Action action = () => DomainValidation.NotNull(value, "Value");
            action.Should().NotThrow();
        }

        [Fact(DisplayName = nameof(NotNullThrowWhenNull))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullThrowWhenNull()
        {
            string? value = null;
            Action action = () => DomainValidation.NotNull(value, "fieldName");
            action.Should().Throw<EntityValidationException>().WithMessage("fieldName should not be null");
        }

        // Não ser null ou vazio
        [Theory(DisplayName = nameof(NotNullOrEmptyThrowWhenEmpty))]
        [Trait("Domain", "DomainValidation - Validation")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NotNullOrEmptyThrowWhenEmpty(string? target)
        {
            Action action = () => DomainValidation.NotNullOrEmpty(target, "fieldName");
            action.Should().Throw<EntityValidationException>().WithMessage("fieldName should not be null or empty");
        }

        [Fact(DisplayName = nameof(NotNullOrEmptyOk))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullOrEmptyOk()
        {
            var target = Faker.Commerce.ProductName();
            Action action = () => DomainValidation.NotNullOrEmpty(target, "fieldName");
            action.Should().NotThrow();
        }
        // Tamanho mínimo de string
        // Tamanho máximo de string
    }
}

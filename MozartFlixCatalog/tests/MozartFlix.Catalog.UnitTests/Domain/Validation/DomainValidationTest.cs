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
            string value = null;
            Action action = () => DomainValidation.NotNull(value, "FieldName");
            action.Should().Throw<EntityValidationException>().WithMessage("FieldName should not be null");
        }

        // Não ser null ou vazio
        // Tamanho mínimo de string
        // Tamanho máximo de string
    }
}

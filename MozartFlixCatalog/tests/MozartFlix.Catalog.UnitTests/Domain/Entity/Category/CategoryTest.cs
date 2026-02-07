using MozartFlix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DomainEntity = MozartFlix.Catalog.Domain.Entity;

namespace MozartFlix.Catalog.UnitTests.Domain.Entity.Category
{
    public class CategoryTest
    {
        [Fact(DisplayName = nameof(Instantiate))]
        [Trait("Domain", "Category - Aggregates")]
        public void Instantiate()
        {
            // Escalando o modelo de teste para os "3 A"
            // Arrange ("A" referente à parte dos dados)
            var validData = new
            {
                Name = "category name",
                Description = "category description"
            };

            // Act ("A" referente à ação esperada do teste)
            var datetimeBefore = DateTime.Now;
            var category = new DomainEntity.Category(validData.Name, validData.Description);
            var datetimeAfter = DateTime.Now;

            // Assert ("A" referente às validações de regras e sucesso da criação)
            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt > datetimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.True(category.IsActive);
        }


        [Theory(DisplayName = nameof(InstantiateWithIsActive))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData(true)]
        [InlineData(false)]
        public void InstantiateWithIsActive(bool isActive)
        {
            // Escalando o modelo de teste para os "3 A"
            // Arrange ("A" referente à parte dos dados)
            var validData = new
            {
                Name = "category name",
                Description = "category description"
            };

            // Act ("A" referente à ação esperada do teste)
            var datetimeBefore = DateTime.Now;
            var category = new DomainEntity.Category(validData.Name, validData.Description, isActive);
            var datetimeAfter = DateTime.Now;

            // Assert ("A" referente às validações de regras e sucesso da criação)
            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt > datetimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.Equal(isActive, category.IsActive);
        }


        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public void InstantiateErrorWhenNameIsEmpty(string? name)
        {
            Action action =
                () => new DomainEntity.Category(name!, "Category Description");
            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should not be empty or null", exception.Message);
        }


        [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsNull))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateErrorWhenDescriptionIsNull()
        {
            Action action =
                () => new DomainEntity.Category("Category Name", null!);
            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Description should not be null", exception.Message);
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsLessThan3Characters))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("a")]
        [InlineData("ca")]
        public void InstantiateErrorWhenNameIsLessThan3Characters(String invalidName)
        {
            Action action =
                () => new DomainEntity.Category(invalidName, "Category Ok Description");
            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should be at least 3 characters long", exception.Message);
        }


        [Fact(DisplayName = nameof(InstantiateErrorWhenNameIsGreaterThan255Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateErrorWhenNameIsGreaterThan255Characters()
        {
            var invalidName = String.Join(null, Enumerable.Range(0, 255).Select(_ => "a"));
            Action action =
                () => new DomainEntity.Category(invalidName, "Category Ok Description");
            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should be at less or equal 255 characters long", exception.Message);
        }


        [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsGreaterThan10000Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateErrorWhenDescriptionIsGreaterThan10000Characters()
        {
            var invalidDescription = String.Join(null, Enumerable.Range(0, 10000).Select(_ => "a"));
            Action action =
                () => new DomainEntity.Category("Category Name", invalidDescription);
            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Description should be at less or equal 10000 characters long", exception.Message);
        }


        // Nome no mínimo 3 caracteres e no máximo 755 caracteres
        // descrição deve ter no máximo 10.000 caracteres
    }


}

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
    }


}

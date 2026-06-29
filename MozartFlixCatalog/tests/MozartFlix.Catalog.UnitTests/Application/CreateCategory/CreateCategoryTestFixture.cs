using Moq;
using MozartFlix.Catalog.Application.Interfaces;
using MozartFlix.Catalog.Application.UseCases.Category.CreateCategory;
using MozartFlix.Catalog.Domain.Repository;
using MozartFlix.Catalog.UnitTests.Common;
using MozartFlix.Catalog.UnitTests.Domain.Entity.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.UnitTests.Application.CreateCategory
{
    public class CreateCategoryTestFixture : BaseFixture
    {
        public Mock<ICategoryRepository> GetRepositoryMock() 
            => new();

        public Mock<IUnitOfWork> GetUnitOfWorkMock() 
            => new();

        public string GetValidCategoryName()
        {
            var categoryName = "";
            while (categoryName.Length < 3)
                categoryName = Faker.Commerce.Categories(1)[0];
            if (categoryName.Length > 255)
                categoryName = categoryName[..255];
            return categoryName;
        }

        public string GetValidCategoryDescription()
        {
            var categoryDescription = Faker.Commerce.ProductDescription();
            if (categoryDescription.Length > 10_000)
                categoryDescription = categoryDescription[..10_000];
            return categoryDescription;
        }

        public bool GetRandomBoolean() 
            => (new Random()).NextDouble() < 0.5;

        public CreateCategoryInput GetInput() 
            => new(GetValidCategoryName(), GetValidCategoryDescription(), GetRandomBoolean());
        


        [CollectionDefinition(nameof(CreateCategoryTestFixture))]
        public class CreateCategoryTestFixtureCollection : ICollectionFixture<CreateCategoryTestFixture> { }
    }
}

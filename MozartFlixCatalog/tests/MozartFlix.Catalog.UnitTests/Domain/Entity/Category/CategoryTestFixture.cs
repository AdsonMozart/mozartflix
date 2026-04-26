using System;
using System.Collections.Generic;
using System.Text;
using DomainEntity = MozartFlix.Catalog.Domain.Entity;

namespace MozartFlix.Catalog.UnitTests.Domain.Entity.Category
{
    public class CategoryTestFixture
    {
        public DomainEntity.Category GetValidCategory() => new DomainEntity.Category("Category Name", "Category Description");
    }

    [CollectionDefinition(nameof(CategoryTestFixture))]
    public class CategoryTestFixtureCollection : ICollectionFixture<CategoryTestFixture> { }
}

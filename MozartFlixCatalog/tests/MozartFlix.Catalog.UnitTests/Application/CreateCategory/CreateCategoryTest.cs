using FluentAssertions;
using Moq;
using MozartFlix.Catalog.Application.Interfaces;
using MozartFlix.Catalog.Domain.Entity;
using MozartFlix.Catalog.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases = MozartFlix.Catalog.Application.UseCases.Category.CreateCategory;

namespace MozartFlix.Catalog.UnitTests.Application.CreateCategory
{
    public class CreateCategoryTest
    {
        [Fact(DisplayName = nameof(CreateCategory))]
        [Trait("Application", "CreateCategory - Use Cases")]
        public async void CreateCategory()
        {
            var repositoryMock = new Mock<ICategoryRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new UseCases.CreateCategory(repositoryMock.Object, unitOfWorkMock.Object);
            var input = new UseCases.CreateCategoryInput("Category Name", "Category Description", true);

            var output = await useCase.Handle(input, CancellationToken.None);

            repositoryMock.Verify(repository => repository.Insert(It.IsAny<Category>(), It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(unitOfWork => unitOfWork.Commit(It.IsAny<CancellationToken>()), Times.Once);

            output.Should().NotBeNull();
            output.Name.Should().Be("Category Name");
            output.Description.Should().Be("Category Description");
            output.IsActive.Should().Be(true);
            output.Id.Should().NotBeEmpty();
            output.CreatedAt.Should().NotBeSameDateAs(default(DateTime));
        }   
    }
}

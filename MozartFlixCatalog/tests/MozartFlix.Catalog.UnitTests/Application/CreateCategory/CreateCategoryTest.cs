using FluentAssertions;
using Moq;
using MozartFlix.Catalog.Application.UseCases.Category.CreateCategory;
using MozartFlix.Catalog.Domain.Entity;
using MozartFlix.Catalog.Domain.Exceptions;
using MozartFlix.Catalog.UnitTests.Domain.Entity.Category;
using UseCases = MozartFlix.Catalog.Application.UseCases.Category.CreateCategory;

namespace MozartFlix.Catalog.UnitTests.Application.CreateCategory
{
    [Collection(nameof(CreateCategoryTestFixture))]
    public class CreateCategoryTest
    {
        private readonly CreateCategoryTestFixture _fixture;

        public CreateCategoryTest(CreateCategoryTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = nameof(CreateCategory))]
        [Trait("Application", "CreateCategory - Use Cases")]
        public async void CreateCategory()
        {
            var repositoryMock = _fixture.GetRepositoryMock();
            var unitOfWorkMock = _fixture.GetUnitOfWorkMock();
            var useCase = new UseCases.CreateCategory(repositoryMock.Object, unitOfWorkMock.Object);
            var input = _fixture.GetInput();

            var output = await useCase.Handle(input, CancellationToken.None);

            repositoryMock.Verify(repository => repository.Insert(It.IsAny<Category>(), It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(unitOfWork => unitOfWork.Commit(It.IsAny<CancellationToken>()), Times.Once);

            output.Should().NotBeNull();
            output.Name.Should().Be(input.Name);
            output.Description.Should().Be(input.Description);
            output.IsActive.Should().Be(input.IsActive);
            output.Id.Should().NotBeEmpty();
            output.CreatedAt.Should().NotBeSameDateAs(default(DateTime));
        }


        [Theory(DisplayName = nameof(ThrowWhenCantInstantiateAggregate))]
        [Trait("Application", "CreateCategory - Use Cases")]
        [MemberData(nameof(GetInvalidInputs))]
        public async void ThrowWhenCantInstantiateAggregate(CreateCategoryInput input, string exceptionMessage)
        {
            var useCase = new UseCases.CreateCategory(_fixture.GetRepositoryMock().Object, _fixture.GetUnitOfWorkMock().Object);

            Func<Task> task = async () =>  await useCase.Handle(input, CancellationToken.None);
            await task.Should().ThrowAsync<EntityValidationException>().WithMessage(exceptionMessage);
        }

        public static IEnumerable<object[]> GetInvalidInputs()
        {
            var fixture = new CreateCategoryTestFixture();
            var invalidInputList = new List<object[]>();

            // nome não pode ser menor que 3 caracteres
            var invalidInputShortName = fixture.GetInput();
            invalidInputShortName.Name = invalidInputShortName.Name.Substring(0, 2);
            invalidInputList.Add(new object[]
            {
                invalidInputShortName, "Name should be at least 3 characters long"
            });

            // nome não pode ser maior que 255 caracteres
            var invalidInputTooLongName = fixture.GetInput();
            var tooLongNameForCategory = fixture.Faker.Commerce.ProductName();

            while (tooLongNameForCategory.Length <= 255)
                tooLongNameForCategory = $"{tooLongNameForCategory} {fixture.Faker.Commerce.ProductName()}";

            invalidInputTooLongName.Name = tooLongNameForCategory;
            invalidInputList.Add(new object[]
            {
                invalidInputTooLongName, "Name should be at less or equal 255 characters long"
            });
            // description não pode ser null
            // nome não pode ser null

            return invalidInputList;
        }
    }

}

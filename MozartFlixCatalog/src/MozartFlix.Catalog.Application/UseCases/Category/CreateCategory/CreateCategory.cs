using MozartFlix.Catalog.Application.Interfaces;
using MozartFlix.Catalog.Domain.Repository;
using DomainEntity = MozartFlix.Catalog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Application.UseCases.Category.CreateCategory
{

    public class CreateCategory : ICreateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryOutput> Handle(CreateCategoryInput input, CancellationToken cancellationToken)
        {
            var category = new DomainEntity.Category(input.Name, input.Description, input.IsActive);

            await _categoryRepository.Insert(category, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return new CreateCategoryOutput(category.Id, category.Name, category.Description, category.IsActive, category.CreatedAt);
        }
    }
}

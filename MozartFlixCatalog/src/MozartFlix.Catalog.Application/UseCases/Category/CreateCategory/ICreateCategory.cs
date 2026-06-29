using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Application.UseCases.Category.CreateCategory
{
    public interface ICreateCategory
    {
        public Task<CreateCategoryOutput> Handle(CreateCategoryInput input, CancellationToken cancellationToken);
    }
}

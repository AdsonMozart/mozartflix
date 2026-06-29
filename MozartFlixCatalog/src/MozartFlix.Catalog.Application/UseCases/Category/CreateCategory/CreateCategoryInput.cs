using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Application.UseCases.Category.CreateCategory
{
    public class CreateCategoryInput
    {

        public String Name{ get; set; }
        public String Description{ get; set; }
        public bool IsActive{ get; set; }


        public CreateCategoryInput(string name, string? description = null, bool isActive = true)
        {
            Name = name;
            Description = description ?? "";
            IsActive = isActive;
        }
    }
}

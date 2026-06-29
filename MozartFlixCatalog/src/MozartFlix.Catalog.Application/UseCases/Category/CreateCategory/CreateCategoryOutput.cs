using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Application.UseCases.Category.CreateCategory
{
    public class CreateCategoryOutput
    {
        public Guid Id {  get; set; }
        public String Name{ get; set; }
        public String Description{ get; set; }
        public bool IsActive{ get; set; }
        public DateTime CreatedAt { get; set; }


        public CreateCategoryOutput(Guid id, string name, string description, bool isActive, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = createdAt;
        }
    }
}

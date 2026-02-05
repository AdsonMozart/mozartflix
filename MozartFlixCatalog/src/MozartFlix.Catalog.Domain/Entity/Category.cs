using MozartFlix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Domain.Entity
{
    public class Category
    {

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Construtor
        public Category(string name, string description, bool isActive = true)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = DateTime.Now;

            Validate();
        }

        public void Validate()
        {
            if(String.IsNullOrWhiteSpace(Name))
                throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

            if (Description == null)
                throw new EntityValidationException($"{nameof(Description)} should not be null");
        }

    }
}

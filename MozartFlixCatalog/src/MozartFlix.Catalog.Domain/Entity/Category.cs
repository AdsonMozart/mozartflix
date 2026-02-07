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

        public void Activate()
        {
            IsActive = true;
            Validate();
        }

        public void Deactivate()
        {
            IsActive = false;
            Validate();
        }

        public void Validate()
        {
            if(String.IsNullOrWhiteSpace(Name))
                throw new EntityValidationException($"{nameof(Name)} should not be empty or null");
            if (Description == null)
                throw new EntityValidationException($"{nameof(Description)} should not be null");
            if (Name.Length < 3)
                throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters long");
            if (Name.Length >= 255)
                throw new EntityValidationException($"{nameof(Name)} should be at less or equal 255 characters long");
            if (Description.Length >= 10000)
                throw new EntityValidationException($"{nameof(Description)} should be at less or equal 10000 characters long");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.Domain.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string? message) : base(message)
        {
        }
    }
}

using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozartFlix.Catalog.UnitTests.Common
{
    public abstract class BaseFixture
    {
        public Faker Faker { get; set; }
        protected BaseFixture() => Faker = new Faker("pt_BR");
    }
}

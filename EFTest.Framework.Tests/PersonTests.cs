using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using EFTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFTest.Framework.Tests
{
    [TestClass]
    public class PersonTests
    {
        private SandwichContext _context;

        [TestInitialize]
        public void Setup()
        {
            //Create an in-memory DbConnection https://entityframework-effort.net/
            var dbConnection = Effort.DbConnectionFactory.CreateTransient();
            this._context = new SandwichContext(dbConnection);
        }

        [TestMethod]
        public void FirstName_HasMaxLength()
        {
            try
            {
                var personWithLongName = new Person
                {
                    FirstName = new string('a', 51)
                };

                this._context.Set<Person>().Add(personWithLongName);
                this._context.SaveChanges();

                Assert.Fail("Should have thrown an exception");
            }
            catch (DbEntityValidationException ex)
            {
                var message = ex.EntityValidationErrors?.Single().ValidationErrors.Single().ErrorMessage;
                StringAssert.Contains(message, 
                    "The field FirstName must be a string or array type with a maximum length of '50'.");
            }
        }
    }
}

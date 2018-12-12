using System;
using System.Collections.Generic;
using System.Linq;
using EFTest.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFTest.Core.Tests
{
    [TestClass]
    public class PersonTests
    {
        private SandwichContext _context;

        [TestInitialize]
        public void Setup()
        {
            //https://garywoodfine.com/entity-framework-core-memory-testing-database/
            var connection = new SqliteConnection("DataSource=:memory:");
            var dbOptions = new DbContextOptionsBuilder<SandwichContext>()
                .UseSqlite(connection)
                .Options;

            _context = new SandwichContext(dbOptions);
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void FirstName_HasDefaultValue()
        {
            var personWithLongName = new Person();
            
            this._context.Set<Person>().Add(personWithLongName);
            this._context.SaveChanges();
            Assert.AreEqual(personWithLongName.FirstName, "Adam");
        }


        [TestMethod]
        public void NullableUniqueField_IsNotUniqueIfAdam()
        {
            var value = "Adam";

            var first = new Person
            {
                FirstName = value
            };
            var second = new Person
            {
                FirstName = value
            };

            this._context.Set<Person>()
                .AddRange(new List<Person> { first, second });

            var foo = this._context.Set<Person>().ToList();
            var result = this._context.SaveChanges();

            //Can check the ids are > 0 , or just leave it. We just want to ensure no exception has been thrown
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void NullableUniqueField_IsUniqueIfNotAdam()
        {
            try
            {
                var duplicateValue = "Phil";

                var first = new Person
                {
                    FirstName = duplicateValue
                };
                var second = new Person
                {
                    FirstName = duplicateValue
                };

                this._context.Set<Person>()
                    .AddRange(new List<Person> { first, second });
                this._context.SaveChanges();

                Assert.Fail("Should have thrown an exception");
            }
            catch (DbUpdateException e)
            {
                var message = e.InnerException.Message;
                StringAssert.Contains(message, "UNIQUE constraint failed: Person.FirstName");
            }

        }
    }
}

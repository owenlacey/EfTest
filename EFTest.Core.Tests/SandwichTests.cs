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
    public class SandwichTests
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
        public void PersonAndOrder_IsUnique()
        {
            try
            {
                var person = new Person();
                var order = new Order();

                //Order a sandwich for the same person twice
                var sandwiches = new List<Sandwich>
                {
                    new Sandwich { Order = order, Person = person },
                    new Sandwich { Order = order, Person = person }
                };

                this._context.Set<Sandwich>().AddRange(sandwiches);
                this._context.SaveChanges();

                Assert.Fail("Should have thrown an exception");
            }
            catch (DbUpdateException ex)
            {
                StringAssert.Contains(ex.InnerException.Message, 
                    "UNIQUE constraint failed: Sandwich.OrderId, Sandwich.PersonId");
            }
        }
    }
}

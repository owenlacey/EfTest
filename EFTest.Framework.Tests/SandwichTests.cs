using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using EFTest.Framework;
using EFTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFTest.Framework.Tests
{
    [TestClass]
    public class SandwichTests
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
                //😍 - not ideal
                var message = ex.InnerException?.InnerException?.InnerException?.Message;
                StringAssert.Contains(message,
                    "Unique key violation (OrderId, PersonId).");
            }
        }
    }
}

﻿using System.Data.Entity.ModelConfiguration;
using EFTest.Models;

namespace EFTest.Framework.Mappings
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
        }
    }
}

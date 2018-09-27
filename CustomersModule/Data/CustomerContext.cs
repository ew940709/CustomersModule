using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CustomersModule.Models;

namespace CustomersModule.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("DefaultConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
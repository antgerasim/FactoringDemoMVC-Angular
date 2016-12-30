using System.Data.Entity.Migrations;
using NfcDemo.Models;

namespace NfcDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NfcDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NfcDemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Suppliers.AddOrUpdate(x => x.Id,
                new Supplier {Id = 1, CompanyName = "Alfa Supplies Inc.", Itin = 912877521},
                new Supplier {Id = 2, CompanyName = "Beta Company Corp.", Itin = 911719874},
                new Supplier {Id = 3, CompanyName = "Omega Trades Corp.", Itin = 930735858},
                new Supplier {Id = 4, CompanyName = "Delta Capital Ltd.", Itin = 929695763}
                );


            context.Deliveries.AddOrUpdate(x => x.Id,
                new Delivery {Id = 1, DelNo = "A0001", SupplierId = 1, Currency = 810, Sum = 40000},
                new Delivery {Id = 2, DelNo = "A0002", SupplierId = 1, Currency = 840, Sum = 1200},
                new Delivery {Id = 3, DelNo = "A0003", SupplierId = 1, Currency = 810, Sum = 1000},
                new Delivery {Id = 4, DelNo = "b1-1", SupplierId = 2, Currency = 810, Sum = 23000},
                new Delivery {Id = 5, DelNo = "b1-2", SupplierId = 2, Currency = 840, Sum = 890},
                new Delivery {Id = 6, DelNo = "O1001-1", SupplierId = 3, Currency = 810, Sum = 11000},
                new Delivery {Id = 7, DelNo = "O1001-2", SupplierId = 3, Currency = 840, Sum = 8040}
                );
        }
    }
}
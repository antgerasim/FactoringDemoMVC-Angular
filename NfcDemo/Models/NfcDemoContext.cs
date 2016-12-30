using System.Data.Entity;

namespace NfcDemo.Models
{
    public class NfcDemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public NfcDemoContext() : base("name=NfcDemoContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NfcDemoContext>());
        }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
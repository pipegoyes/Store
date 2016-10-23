using System.Data.Entity;
using Store.Data.Configuration;
using Store.Model.Dto;

namespace Store.Data.Repositories
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities") { }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
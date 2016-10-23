using System.Data.Entity.ModelConfiguration;
using Store.Model.Dto;

namespace Store.Data.Configuration
{
    public class GadgetConfiguration : EntityTypeConfiguration<Gadget>
    {
        public GadgetConfiguration()
        {
            ToTable("Gadget");
            Property(s => s.Name).IsRequired().HasMaxLength(50);
            Property(s => s.Price).IsRequired().HasPrecision(8,2);
            Property(s => s.CategoryID).IsRequired();
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Store.Model.Dto;

namespace Store.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category> 
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            Property(m => m.Name).IsRequired().HasMaxLength(50);

        }
    }
}
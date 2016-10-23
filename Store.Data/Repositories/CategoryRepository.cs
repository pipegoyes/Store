using System;
using System.Linq;
using Store.Data.Interface;
using Store.Model.Dto;

namespace Store.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string name);
    }

    public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Category GetCategoryByName(string name)
        {
            var foundCategory = DbContext.Categories.FirstOrDefault(s => s.Name == name);
            return foundCategory;
        }

        public override void Update(Category entity)
        {
            entity.DateUpdate = DateTime.Now;
            base.Update(entity);
        }
    }
    
}
using System.Collections.Generic;
using System.Linq;
using Store.Data.Repositories;
using Store.Data.UnitOfWork;
using Store.Model.Dto;

namespace Store.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categorysRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
        {
            this._categorysRepository = categorysRepository;
            this._unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _categorysRepository.GetAll();
            else
                return _categorysRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = _categorysRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = _categorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            _categorysRepository.Add(category);
        }

        public void SaveCategory()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
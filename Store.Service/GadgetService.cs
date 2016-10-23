using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Store.Model.Dto;
using Store.Data;
using Store.Data.Repositories;
using Store.Data.UnitOfWork;

namespace Store.Service
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadget(string categoryName, string gadgetName);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _gadgetRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GadgetService(IGadgetRepository gadgetRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _gadgetRepository = gadgetRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            var result = _gadgetRepository.GetAll();
            _categoryRepository.GetAll();
            return result;
        }
        

        public IEnumerable<Gadget> GetCategoryGadget(string categoryName, string gadgetName = null)
        {
            var foundCategory = _categoryRepository.GetCategoryByName(categoryName);
            var result = foundCategory.Gadgets.Where(g => gadgetName != null && g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
            return result;
        }

        public Gadget GetGadget(int id)
        {
            var result = _gadgetRepository.GetById(id);
            return result;
        }

        public void CreateGadget(Gadget gadget)
        {
            _gadgetRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            _unitOfWork.Commit();
        }
    }
}
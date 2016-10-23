using Store.Data.Interface;
using Store.Model.Dto;

namespace Store.Data.Repositories
{
    public interface IGadgetRepository : IRepository<Gadget>
    {
        
    }

    public class GadgetRepository : RepositoryBase<Gadget>, IGadgetRepository
    {
        public GadgetRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

    }
}
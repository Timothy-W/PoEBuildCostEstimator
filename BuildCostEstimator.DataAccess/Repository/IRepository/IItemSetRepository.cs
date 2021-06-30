using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IItemSetRepository : IRepository<ItemSet>
    {
        void Update(ItemSet itemSet);
    }
}

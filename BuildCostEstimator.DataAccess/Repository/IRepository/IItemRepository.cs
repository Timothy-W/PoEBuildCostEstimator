using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        void Update(Item item);
    }
}

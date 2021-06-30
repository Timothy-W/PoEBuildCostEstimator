using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IItemSetRelationshipRepository : IRepository<ItemSetRelationship>
    {
        void Update(ItemSetRelationship itemSetRelationship);
    }
}

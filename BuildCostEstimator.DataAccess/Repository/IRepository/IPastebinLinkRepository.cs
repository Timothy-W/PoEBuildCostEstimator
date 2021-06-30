using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IPastebinLinkRepository : IRepository<PastebinLink>
    {
        void Update(PastebinLink pastebinLink);
    }
}

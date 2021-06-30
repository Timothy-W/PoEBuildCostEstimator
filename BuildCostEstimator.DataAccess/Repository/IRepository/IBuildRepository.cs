using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IBuildRepository : IRepository<Build>
    {
        void Update(Build build);
    }
}

using System;

namespace BuildCostEstimator.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPastebinLinkRepository PastebinLinks { get; }
        IItemRepository Items { get; }
        IItemSetRepository ItemSets { get; }
        IBuildRepository Builds { get; }

        IItemSetRelationshipRepository ItemSetRelationships { get; }
        IStoredProcedureCall StoredProcedureCall { get; }


        void Save();
    }
}

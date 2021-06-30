using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Data;
using BuildCostEstimator.DataAccess.Repository.IRepository;


namespace BuildCostEstimator.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            PastebinLinks = new PastebinLinkRepository(_db);
            StoredProcedureCall = new StoredProcedureCall(_db);
            Items = new ItemRepository(_db);
            ItemSets = new ItemSetRepository(_db);
            Builds = new BuildRepository(_db);
            ItemSetRelationships = new ItemSetRelationshipRepository(_db);
        }

        public IPastebinLinkRepository PastebinLinks { get; private set; }
        public IItemRepository Items { get; private set; }
        public IItemSetRepository ItemSets { get; private set; }
        public IItemSetRelationshipRepository ItemSetRelationships { get; private set; }
        public IBuildRepository Builds { get; private set; }
        public IStoredProcedureCall StoredProcedureCall { get; private set; }
        
        
      

        public void Dispose()
        {
            _db?.Dispose();
            //StoredProcedureCall?.Dispose(); // Auto generated
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

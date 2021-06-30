using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Data;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using BuildCostEstimator.Models;


namespace BuildCostEstimator.DataAccess.Repository
{
    public class ItemSetRepository : Repository<ItemSet>, IItemSetRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemSetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ItemSet itemSet)
        {
            var objFromDb = _db.ItemSets.FirstOrDefault(s => s.Id == itemSet.Id);

            if (objFromDb != null)
            {
                objFromDb.ItemSetTitle = itemSet.ItemSetTitle;
                objFromDb.ItemSetXmlId = itemSet.ItemSetXmlId;
                objFromDb.BuildId = itemSet.BuildId;
            }

        }
    }
}

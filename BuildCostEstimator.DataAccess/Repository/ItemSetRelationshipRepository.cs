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
    public class ItemSetRelationshipRepository : Repository<ItemSetRelationship>, IItemSetRelationshipRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemSetRelationshipRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ItemSetRelationship itemSetRelationship)
        {
            var objFromDb = _db.ItemSetRelationships.FirstOrDefault(
                s => s.ItemId == itemSetRelationship.ItemId 
                     && s.ItemSetId == itemSetRelationship.ItemSetId);

            if (objFromDb != null)
            {
                // Should we be trying to update items in the dictionary of items?
                objFromDb.ItemSetId = itemSetRelationship.ItemSetId;
                objFromDb.ItemSet = itemSetRelationship.ItemSet;
                objFromDb.ItemId = itemSetRelationship.ItemId;
                objFromDb.Item = itemSetRelationship.Item;
            }

        }
    }
}

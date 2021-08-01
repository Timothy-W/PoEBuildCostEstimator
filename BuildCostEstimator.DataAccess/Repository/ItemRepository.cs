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
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Item item)
        {
            var objFromDb = _db.Items.FirstOrDefault(s => s.Id == item.Id);

            if (objFromDb != null){
                objFromDb.Name = item.Name;
                objFromDb.BaseType = item.BaseType;
                objFromDb.Rarity = item.Rarity;
                objFromDb.ItemLevel = item.ItemLevel;
                objFromDb.LevelReq = item.LevelReq;
                objFromDb.CostInChaos = item.CostInChaos;
                objFromDb.PobItemId = item.PobItemId;
                objFromDb.Sockets = item.Sockets;
                objFromDb.Influences = item.Influences;
                objFromDb.ImplicitMods = item.ImplicitMods;
                objFromDb.AffixMods = item.AffixMods;
                objFromDb.IsCorrupted = item.IsCorrupted;


            }
        }
    }
}

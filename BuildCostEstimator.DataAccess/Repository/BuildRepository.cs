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
    public class BuildRepository : Repository<Build>, IBuildRepository
    {
        private readonly ApplicationDbContext _db;

        public BuildRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Build build)
        {
            var objFromDb = _db.Builds.FirstOrDefault(b => b.Id == build.Id);

            if (objFromDb != null)
            {
                // Should we be trying to update items in the collection?
                objFromDb.Ascendancy = build.Ascendancy;
                objFromDb.Class = build.Class;
                objFromDb.PastebinLinkId = build.PastebinLinkId;
                objFromDb.Url = build.Url;
                objFromDb.ItemSets = build.ItemSets;

            }

        }
    }
}

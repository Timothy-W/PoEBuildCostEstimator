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
    public class PastebinLinkRepository : Repository<PastebinLink>, IPastebinLinkRepository
    {
        private readonly ApplicationDbContext _db;

        public PastebinLinkRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PastebinLink pastebinLink)
        {
            var objFromDb = _db.PastebinLinks.FirstOrDefault(s => s.Id == pastebinLink.Id);

            if (objFromDb != null){
                objFromDb.PastebinUrl = pastebinLink.PastebinUrl;
            }
        }
    }
}

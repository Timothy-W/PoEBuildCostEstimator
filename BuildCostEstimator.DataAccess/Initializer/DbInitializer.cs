using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildCostEstimator.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private ApplicationDbContext _db { get; }

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }


        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                //Log them
                throw;
            }
        }
    }
}

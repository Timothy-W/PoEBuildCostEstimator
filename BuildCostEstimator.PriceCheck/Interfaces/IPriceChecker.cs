using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.PriceCheck.Interfaces
{
    public interface IPriceChecker
    {
        public Task<Item> CheckPriceAsync(Item item);
        
    }
}

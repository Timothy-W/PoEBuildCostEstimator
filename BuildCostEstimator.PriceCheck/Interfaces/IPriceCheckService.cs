using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.PriceCheck.IPriceCheck
{
    public interface IPriceCheckService
    {
        public Task<Item> SinglePriceCheckAsync(Item item);
        public Task<IEnumerable<Item>> MultiplePriceCheckAsync(IEnumerable<Item> items);
    }
    
}

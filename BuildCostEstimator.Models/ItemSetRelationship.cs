using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models
{   
    // Intermediate class for many to many relationship
    public class ItemSetRelationship
    {
        public int ItemSetId { get; set; }
        public ItemSet ItemSet { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}

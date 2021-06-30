using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models
{
    public class Build
    {
        public Build()
        {
            this.ItemSets = new HashSet<ItemSet>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        public ISet<ItemSet> ItemSets;

        [Required] 
        public string Class { get; set; }

        [Required]
        public string Ascendancy { get; set; }





        // ForeignKeys
        [Required]
        public int PastebinLinkId { get; set; }

        [ForeignKey("PastebinLinkId")] 
        public PastebinLink Url { get; set; }
             
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models
{
    public class ItemSet
    {

        [Key] 
        public int Id  { get; set; }
        [Required, Display(Name = "Item Set Name")]
        public string ItemSetTitle { get; set; }
        [Required, Display(Name = "Item Set Id in PoB")] 
        public int ItemSetXmlId { get; set; }
        

        
        public IList<ItemSetRelationship> ItemSetRelationships { get; set; } = new List<ItemSetRelationship>();



        // ForeignKeys
        public int BuildId { get; set; }
        [ForeignKey("BuildId")]
        public Build Build { get; set; }

    }
}

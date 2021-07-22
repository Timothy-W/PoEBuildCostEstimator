using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required, Display(Name = "Cost (Chaos)")]
        public double CostInChaos { get; set; }

        [Required, MaxLength(50)] 
        public string Name { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Base Type")]
        public string BaseType { get; set; }

        [Required, MaxLength(10)] 
        public string Rarity { get; set; }

        [Required, Display(Name = "PoB Item Id")]
        public int PobItemId { get; set; }

        [Display(Name = "Item Level")]

        public int ItemLevel { get; set; }

        [Display(Name = "Level Requirement")]

        public int LevelReq { get; set; }

        [Display(Name = "Sockets")] 
        public string Sockets { get; set; }


        [Display(Name = "Influences")] 
        public string Influences { get; set; }

        [Display(Name = "Implicit Modifiers")] 
        public string ImplicitMods { get; set; }


        [JsonIgnore]
        public IList<ItemSetRelationship> ItemSetRelationships { get; set; } = new List<ItemSetRelationship>();


        //// ForeignKeys
        //public int ItemSetId { get; set; }
        //[ForeignKey("ItemSetId")] 
        //public ItemSet ItemSet { get; set; } //Navigation Prop

    }
}

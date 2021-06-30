using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models.PoePricesModels
{
    public class PoePricesModel
    {
        public float min { get; set; }
        public float max { get; set; }
        public string currency { get; set; }
        public string warning_msg { get; set; }
        public int error { get; set; }
        //public object[][] pred_explanation { get; set; } // Exception
        //public float pred_confidence_score { get; set; }
        public string error_msg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHost.Models
{
    public class ProductionSegmentResponseModel
    {
        [Key]
        public long oid { get; set; }
        public string errorMessage { get; set; }
        
        public DateTime dateRecieved { get; set; }

        public int temperature { get; set; }

        public ProductionResponseModel ProductionResponseModel { get; set; }
    }
}
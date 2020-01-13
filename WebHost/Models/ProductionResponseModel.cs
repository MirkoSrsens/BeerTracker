using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHost.Models
{
    public class ProductionResponseModel
    {
        [Key]
        public long oid { get; set; }
        public string equipmentId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime expectedEndTime { get; set; }
        public string beerInProduction { get; set; }
        public List<ProductionSegmentResponseModel> productionSegmentResponses { get; set; }

        public ProductionResponseModel(long oid, DateTime startTime)
        {
            this.oid = oid;
            this.equipmentId = Guid.NewGuid().ToString();
            this.startTime = startTime;
            this.expectedEndTime = startTime.AddHours(3);
            this.beerInProduction = "Lager";
            this.productionSegmentResponses = new List<ProductionSegmentResponseModel>();
            for(int i=0; i< 10; i++)
            {
                productionSegmentResponses.Add(new ProductionSegmentResponseModel()
                {
                    oid = i,
                    dateRecieved = DateTime.Now,
                    errorMessage = "No errors",
                    temperature = i
                });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public DateTime DateOfService { get; set; }
        public decimal CostOfService { get; set; }
        public string Description { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int ServiceProviderId { get; set; }
        [ForeignKey("ServiceProviderId.")]
        public Person Person { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}

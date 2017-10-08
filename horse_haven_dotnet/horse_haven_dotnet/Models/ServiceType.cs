using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public string Description { get; set; }
        public List<Service> Services { get; set; }
    }
}

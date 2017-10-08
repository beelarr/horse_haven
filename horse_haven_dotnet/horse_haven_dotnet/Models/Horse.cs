using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class Horse
    {
        public int HorseId { get; set; }
        public string HorseHavenId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string CountyOfOrigin { get; set; }

        public int HorseStatusId { get; set; }
        public HorseStatus HorseStatus { get; set; }

        public DateTime ArrivalDate { get; set; } = DateTime.UtcNow;
        public DateTime DepartureDate { get; set; }
        public DateTime EligibleForOwnership { get; set; }

        public int AdopterId { get; set; }
        [ForeignKey("AdopterId")]
        public Person Person { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }

        public List<Boarding> Boardings { get; set; }
        public List<HorseWeight> Weighings { get; set; }
        public List<Service> Services { get; set; }
    }
}

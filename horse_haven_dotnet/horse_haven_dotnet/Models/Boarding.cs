using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class Boarding
    {
        public int BoardingId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int BoardingTypeId { get; set; }
        public BoardingType BoardingType { get; set; }
    }
}

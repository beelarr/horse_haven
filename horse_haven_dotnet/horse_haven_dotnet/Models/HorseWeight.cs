using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class HorseWeight
    {
        public int HorseWeightId { get; set; }
        public DateTime DateWeighed { get; set; } = DateTime.UtcNow;
        public decimal Weight { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }
    }
}

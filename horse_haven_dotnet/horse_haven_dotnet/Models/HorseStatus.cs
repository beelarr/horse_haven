using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class HorseStatus
    {
        public int HorseStatusId { get; set; }
        public string Description { get; set; }
        public List<Horse> Horses { get; set; }
    }
}

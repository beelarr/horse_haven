using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet.Models
{
    public class BoardingType
    {
        public int BoardingTypeId { get; set; }
        public decimal DailyRate { get; set; }
        public string Description { get; set; }
        public List<Boarding> Boardings { get; set; }
    }
}

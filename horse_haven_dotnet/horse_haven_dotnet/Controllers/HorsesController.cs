using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using horse_haven_dotnet.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace horse_haven_dotnet.Controllers
{
    [Route("api/[controller]")]
    public class HorsesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public HorsesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/horses
        [HttpGet]
        public IEnumerable<Horse> Get()
        {
            return _webAPIDataContext.Horses.AsEnumerable();
        }

        // GET api/horses/5
        [HttpGet("{id}")]
        public Horse Get(int id)
        {
            return _webAPIDataContext.Horses.FirstOrDefault(x => x.HorseId == id);
        }

        // GET api/horses/haven/cmks27lm
        [HttpGet("/haven/{haven_id}")]
        public IEnumerable<Horse> GetByHavenId(string haven_id)
        {
            return _webAPIDataContext.Horses.Where(x => x.HorseHavenId == haven_id);
        }

        // GET api/horses/case/7
        [HttpGet("/case/{case_id}")]
        public IEnumerable<Horse> GetByCase(int case_id)
        {
            return _webAPIDataContext.Horses.Where(x => x.CaseId == case_id);
        }

        // GET api/horses/adopter/7
        [HttpGet("/adopter/{adopter_id}")]
        public IEnumerable<Horse> GetByAdopter(int adopter_id)
        {
            return _webAPIDataContext.Horses.Where(x => x.AdopterId == adopter_id);
        }

        // GET api/horses/status/7
        [HttpGet("/status/{status_id}")]
        public IEnumerable<Horse> GetByStatus(int status_id)
        {
            return _webAPIDataContext.Horses.Where(x => x.HorseStatusId == status_id);
        }

        // GET api/horses/current_boarding_type/7
        [HttpGet("/current_boarding_type/{boarding_type_id}")]
        public IEnumerable<Horse> GetByCurrentBoardingType(int boarding_type_id)
        {
            DateTime now = DateTime.UtcNow;
            return _webAPIDataContext.Boardings.Where
                (
                    x => x.EndDate == null
                    && x.BoardingTypeId == boarding_type_id
                    && x.StartDate <= now
                ).Include(b => b.Horse).Select(h => h.Horse);
        }

        // GET api/horses/county/warren
        [HttpGet("/county/{county}")]
        public IEnumerable<Horse> GetByCounty(string county)
        {
            return _webAPIDataContext.Horses.Where(x => x.CountyOfOrigin.ToLower() == county);
        }

        // GET api/horses/arrive_date/7/2017
        [HttpGet("/arrive_date/{month}/{year}")]
        public IEnumerable<Horse> GetByArriveDate(int month, int year)
        {
            return _webAPIDataContext.Horses.Where(x => x.ArrivalDate.Month == month && x.ArrivalDate.Year == year);
        }

        // GET api/horses/upcoming_ownership
        [HttpGet("/upcoming_ownership")]
        public IEnumerable<Horse> GetByOwnDate()
        {
            DateTime now = DateTime.UtcNow;
            DateTime three_months_out = now.AddMonths(3);
            return _webAPIDataContext.Horses.Where(x => x.EligibleForOwnership >= now && x.EligibleForOwnership <= three_months_out);
        }

        // POST api/horses
        [HttpPost]
        public void Post([FromBody]Horse horse)
        {
            _webAPIDataContext.Add(horse);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/horses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Horse horse)
        {
            var selectedHorse = _webAPIDataContext.Horses.AsNoTracking().FirstOrDefaultAsync(x => x.HorseId == id);
            if (selectedHorse != null)
            {
                _webAPIDataContext.Entry(selectedHorse).Context.Update(horse);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/horses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var horse = _webAPIDataContext.Horses.FirstOrDefault(x => x.HorseId == id);
            if (horse != null)
            {
                _webAPIDataContext.Horses.Remove(horse);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

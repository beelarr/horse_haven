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
    public class HorseWeightsController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public HorseWeightsController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/horseweights
        [HttpGet]
        public IEnumerable<HorseWeight> Get()
        {
            return _webAPIDataContext.HorseWeights.AsEnumerable();
        }

        // GET api/horseweights/5
        [HttpGet("{id}")]
        public HorseWeight Get(int id)
        {
            return _webAPIDataContext.HorseWeights.FirstOrDefault(x => x.HorseWeightId == id);
        }

        // GET api/horseweights/horse/5
        [HttpGet("/horse/{id}")]
        public IEnumerable<HorseWeight> GetByHorse(int id)
        {
            return _webAPIDataContext.HorseWeights.Where(x => x.HorseId == id);
        }

        // GET api/horseweights/horse_month/5/7/2017
        [HttpGet("/horse_month/{id}/{month}/{year}")]
        public IEnumerable<HorseWeight> GetByHorseMonth(int id, int month, int year)
        {
            return _webAPIDataContext.HorseWeights.Where(x => x.HorseId == id && x.DateWeighed.Year == year && x.DateWeighed.Month == month);
        }

        // GET api/horseweights/month/7/2017
        [HttpGet("/month/{month}/{year}")]
        public IEnumerable<HorseWeight> GetByDate(int month, int year)
        {
            return _webAPIDataContext.HorseWeights.Where(x => x.DateWeighed.Year == year && x.DateWeighed.Month == month);
        }

        // POST api/horseweights
        [HttpPost]
        public void Post([FromBody]HorseWeight service)
        {
            _webAPIDataContext.Add(service);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/horseweights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]HorseWeight service)
        {
            var selectedHorseWeight = _webAPIDataContext.HorseWeights.AsNoTracking().FirstOrDefaultAsync(x => x.HorseWeightId == id);
            if (selectedHorseWeight != null)
            {
                _webAPIDataContext.Entry(selectedHorseWeight).Context.Update(service);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/horseweights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var service = _webAPIDataContext.HorseWeights.FirstOrDefault(x => x.HorseWeightId == id);
            if (service != null)
            {
                _webAPIDataContext.HorseWeights.Remove(service);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

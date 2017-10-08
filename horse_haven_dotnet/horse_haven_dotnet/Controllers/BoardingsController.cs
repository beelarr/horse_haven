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
    public class BoardingsController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public BoardingsController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/boardings
        [HttpGet]
        public IEnumerable<Boarding> Get()
        {
            return _webAPIDataContext.Boardings.AsEnumerable();
        }

        // GET api/boardings/5
        [HttpGet("{id}")]
        public Boarding Get(int id)
        {
            return _webAPIDataContext.Boardings.FirstOrDefault(x => x.BoardingId == id);
        }

        // GET api/boardings/type/5
        [HttpGet("/type/{id}")]
        public IEnumerable<Boarding> GetByType(int id)
        {
            return _webAPIDataContext.Boardings.Where(x => x.BoardingTypeId == id);
        }

        // GET api/boardings/active_during_month/7/2017
        [HttpGet("/active_during_month/{month}/{year}")]
        public IEnumerable<Boarding> GetByDate(int month, int year)
        {
            return _webAPIDataContext.Boardings.Where
                (
                    x => x.StartDate.Year == year
                    && (x.EndDate == null || x.EndDate.Month >= month)
                    && x.StartDate.Month <= month
                );
        }

        // POST api/boardings
        [HttpPost]
        public void Post([FromBody]Boarding boarding)
        {
            _webAPIDataContext.Add(boarding);
            _webAPIDataContext.SaveChanges();
        }

        // PUT api/boardings/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Boarding boarding)
        {
            var selectedBoarding = _webAPIDataContext.Boardings.AsNoTracking().FirstOrDefault(x => x.BoardingId == id);
            if (selectedBoarding != null)
            {
                _webAPIDataContext.Entry(selectedBoarding).Context.Update(boarding);
                _webAPIDataContext.SaveChanges();
            }
        }

        // DELETE api/boardings/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var boarding = _webAPIDataContext.Boardings.FirstOrDefault(x => x.BoardingId == id);
            if (boarding != null)
            {
                _webAPIDataContext.Boardings.Remove(boarding);
                _webAPIDataContext.SaveChanges();
            }
        }
    }
}

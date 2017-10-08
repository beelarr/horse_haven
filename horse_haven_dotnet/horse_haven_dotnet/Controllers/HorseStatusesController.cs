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
    public class HorseStatusesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public HorseStatusesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/horsestatuses
        [HttpGet]
        public IEnumerable<HorseStatus> Get()
        {
            return _webAPIDataContext.HorseStatuses.AsEnumerable();
        }

        // GET api/horsestatuses/5
        [HttpGet("{id}")]
        public HorseStatus Get(int id)
        {
            return _webAPIDataContext.HorseStatuses.FirstOrDefault(x => x.HorseStatusId == id);
        }

        // POST api/horsestatuses
        [HttpPost]
        public void Post([FromBody]HorseStatus HorseStatus)
        {
            _webAPIDataContext.Add(HorseStatus);
            _webAPIDataContext.SaveChanges();
        }

        // PUT api/horsestatuses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]HorseStatus HorseStatus)
        {
            var selectedHorseStatus = _webAPIDataContext.HorseStatuses.AsNoTracking().FirstOrDefault(x => x.HorseStatusId == id);
            if (selectedHorseStatus != null)
            {
                _webAPIDataContext.Entry(selectedHorseStatus).Context.Update(HorseStatus);
                _webAPIDataContext.SaveChanges();
            }
        }

        // DELETE api/horsestatuses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var HorseStatus = _webAPIDataContext.HorseStatuses.FirstOrDefault(x => x.HorseStatusId == id);
            if (HorseStatus != null)
            {
                _webAPIDataContext.HorseStatuses.Remove(HorseStatus);
                _webAPIDataContext.SaveChanges();
            }
        }
    }
}

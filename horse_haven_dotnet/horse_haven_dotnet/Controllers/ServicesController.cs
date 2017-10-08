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
    public class ServicesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public ServicesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/services
        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return _webAPIDataContext.Services.AsEnumerable();
        }

        // GET api/services/5
        [HttpGet("{id}")]
        public Service Get(int id)
        {
            return _webAPIDataContext.Services.FirstOrDefault(x => x.ServiceId == id);
        }

        // GET api/services/type/5
        [HttpGet("/type/{id}")]
        public IEnumerable<Service> GetByType(int id)
        {
            return _webAPIDataContext.Services.Where(x => x.ServiceTypeId == id);
        }

        // GET api/services/provider/5
        [HttpGet("/provider/{id}")]
        public IEnumerable<Service> GetByProvider(int id)
        {
            return _webAPIDataContext.Services.Where(x => x.ServiceProviderId == id);
        }

        // GET api/services/horse/5
        [HttpGet("/horse/{id}")]
        public IEnumerable<Service> GetByHorse(int id)
        {
            return _webAPIDataContext.Services.Where(x => x.HorseId == id);
        }

        // GET api/services/horse_month/5/7/2017
        [HttpGet("/horse_month/{id}/{month}/{year}")]
        public IEnumerable<Service> GetByHorseMonth(int id, int month, int year)
        {
            return _webAPIDataContext.Services.Where(x => x.HorseId == id && x.DateOfService.Year == year && x.DateOfService.Month == month);
        }

        // GET api/services/month/7/2017
        [HttpGet("/month/{month}/{year}")]
        public IEnumerable<Service> GetByDate(int month, int year)
        {
            return _webAPIDataContext.Services.Where(x => x.DateOfService.Year == year && x.DateOfService.Month == month);
        }

        // POST api/services
        [HttpPost]
        public void Post([FromBody]Service service)
        {
            _webAPIDataContext.Add(service);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/services/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Service service)
        {
            var selectedService = _webAPIDataContext.Services.AsNoTracking().FirstOrDefaultAsync(x => x.ServiceId == id);
            if (selectedService != null)
            {
                _webAPIDataContext.Entry(selectedService).Context.Update(service);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/services/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var service = _webAPIDataContext.Services.FirstOrDefault(x => x.ServiceId == id);
            if (service != null)
            {
                _webAPIDataContext.Services.Remove(service);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

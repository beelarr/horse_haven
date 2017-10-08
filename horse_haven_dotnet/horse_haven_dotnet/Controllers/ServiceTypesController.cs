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
    public class ServiceTypesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public ServiceTypesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/servicetypes
        [HttpGet]
        public IEnumerable<ServiceType> Get()
        {
            return _webAPIDataContext.ServiceTypes.AsEnumerable();
        }

        // GET api/servicetypes/5
        [HttpGet("{id}")]
        public ServiceType Get(int id)
        {
            return _webAPIDataContext.ServiceTypes.FirstOrDefault(x => x.ServiceTypeId == id);
        }

        // POST api/servicetypes
        [HttpPost]
        public void Post([FromBody]ServiceType ServiceType)
        {
            _webAPIDataContext.Add(ServiceType);
            _webAPIDataContext.SaveChanges();
        }

        // PUT api/servicetypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ServiceType ServiceType)
        {
            var selectedServiceType = _webAPIDataContext.ServiceTypes.AsNoTracking().FirstOrDefault(x => x.ServiceTypeId == id);
            if (selectedServiceType != null)
            {
                _webAPIDataContext.Entry(selectedServiceType).Context.Update(ServiceType);
                _webAPIDataContext.SaveChanges();
            }
        }

        // DELETE api/servicetypes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ServiceType = _webAPIDataContext.ServiceTypes.FirstOrDefault(x => x.ServiceTypeId == id);
            if (ServiceType != null)
            {
                _webAPIDataContext.ServiceTypes.Remove(ServiceType);
                _webAPIDataContext.SaveChanges();
            }
        }
    }
}

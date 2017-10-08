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
    public class PersonTypesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public PersonTypesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/boardingtypes
        [HttpGet]
        public IEnumerable<PersonType> Get()
        {
            return _webAPIDataContext.PersonTypes.AsEnumerable();
        }

        // GET api/boardingtypes/5
        [HttpGet("{id}")]
        public PersonType Get(int id)
        {
            return _webAPIDataContext.PersonTypes.FirstOrDefault(x => x.PersonTypeId == id);
        }

        // POST api/boardingtypes
        [HttpPost]
        public void Post([FromBody]PersonType PersonType)
        {
            _webAPIDataContext.Add(PersonType);
            _webAPIDataContext.SaveChanges();
        }

        // PUT api/boardingtypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PersonType PersonType)
        {
            var selectedPersonType = _webAPIDataContext.PersonTypes.AsNoTracking().FirstOrDefault(x => x.PersonTypeId == id);
            if (selectedPersonType != null)
            {
                _webAPIDataContext.Entry(selectedPersonType).Context.Update(PersonType);
                _webAPIDataContext.SaveChanges();
            }
        }

        // DELETE api/boardingtypes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var PersonType = _webAPIDataContext.PersonTypes.FirstOrDefault(x => x.PersonTypeId == id);
            if (PersonType != null)
            {
                _webAPIDataContext.PersonTypes.Remove(PersonType);
                _webAPIDataContext.SaveChanges();
            }
        }
    }
}

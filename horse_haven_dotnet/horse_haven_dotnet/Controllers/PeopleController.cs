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
    public class PeopleController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public PeopleController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/people
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _webAPIDataContext.People.AsEnumerable();
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _webAPIDataContext.People.FirstOrDefault(x => x.PersonId == id);
        }

        // GET api/people/type/5
        [HttpGet("/type/{id}")]
        public IEnumerable<Person> GetByType(int id)
        {
            return _webAPIDataContext.People.Where(x => x.PersonTypeId == id);
        }

        // GET api/people/not_type/5
        [HttpGet("/not_type/{id}")]
        public IEnumerable<Person> GetNotType(int id)
        {
            return _webAPIDataContext.People.Where(x => x.PersonTypeId != id);
        }

        // POST api/people
        [HttpPost]
        public void Post([FromBody]Person Person)
        {
            _webAPIDataContext.Add(Person);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person Person)
        {
            var selectedPerson = _webAPIDataContext.People.AsNoTracking().FirstOrDefaultAsync(x => x.PersonId == id);
            if (selectedPerson != null)
            {
                _webAPIDataContext.Entry(selectedPerson).Context.Update(Person);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Person = _webAPIDataContext.People.FirstOrDefault(x => x.PersonId == id);
            if (Person != null)
            {
                _webAPIDataContext.People.Remove(Person);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

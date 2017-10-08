using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using horse_haven_dotnet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace horse_haven_dotnet.Controllers
{
    [Route("api/[controller]")]
    public class BoardingController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public BoardingController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/boarding
        [HttpGet]
        public IEnumerable<Boarding> Get()
        {
            return _webAPIDataContext.Boardings.AsEnumerable();
        }

        // GET api/boarding/5
        [HttpGet("{id}")]
        public Boarding Get(int id)
        {
            return _webAPIDataContext.Boardings.FirstOrDefault(x => x.BoardingId == id);
        }

        // POST api/boarding
        [HttpPost]
        public void Post([FromBody]Boarding boarding)
        {
            _webAPIDataContext.Add(boarding);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/boarding/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/boarding/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

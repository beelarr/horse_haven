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
    public class CasesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public CasesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/cases
        [HttpGet]
        public IEnumerable<Case> Get()
        {
            return _webAPIDataContext.Cases.AsEnumerable();
        }

        // GET api/cases/5
        [HttpGet("{id}")]
        public Case Get(int id)
        {
            return _webAPIDataContext.Cases.FirstOrDefault(x => x.CaseId == id);
        }

        // POST api/cases
        [HttpPost]
        public void Post([FromBody]Case boarding)
        {
            _webAPIDataContext.Add(boarding);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/cases/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Case boarding)
        {
            var selectedCase = _webAPIDataContext.Cases.AsNoTracking().FirstOrDefaultAsync(x => x.CaseId == id);
            if (selectedCase != null)
            {
                _webAPIDataContext.Entry(selectedCase).Context.Update(boarding);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/cases/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var boarding = _webAPIDataContext.Cases.FirstOrDefault(x => x.CaseId == id);
            if (boarding != null)
            {
                _webAPIDataContext.Cases.Remove(boarding);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

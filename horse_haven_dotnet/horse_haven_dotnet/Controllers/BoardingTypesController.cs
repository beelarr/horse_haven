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
    public class BoardingTypesController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;
        public BoardingTypesController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        // GET: api/boardingtypes
        [HttpGet]
        public IEnumerable<BoardingType> Get()
        {
            return _webAPIDataContext.BoardingTypes.AsEnumerable();
        }

        // GET api/boardingtypes/5
        [HttpGet("{id}")]
        public BoardingType Get(int id)
        {
            return _webAPIDataContext.BoardingTypes.FirstOrDefault(x => x.BoardingTypeId == id);
        }

        // POST api/boardingtypes
        [HttpPost]
        public void Post([FromBody]BoardingType boarding)
        {
            _webAPIDataContext.Add(boarding);
            _webAPIDataContext.SaveChangesAsync();
        }

        // PUT api/boardingtypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BoardingType boarding)
        {
            var selectedBoardingType = _webAPIDataContext.BoardingTypes.AsNoTracking().FirstOrDefaultAsync(x => x.BoardingTypeId == id);
            if (selectedBoardingType != null)
            {
                _webAPIDataContext.Entry(selectedBoardingType).Context.Update(boarding);
                _webAPIDataContext.SaveChangesAsync();
            }
        }

        // DELETE api/boardingtypes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var boarding = _webAPIDataContext.BoardingTypes.FirstOrDefault(x => x.BoardingTypeId == id);
            if (boarding != null)
            {
                _webAPIDataContext.BoardingTypes.Remove(boarding);
                _webAPIDataContext.SaveChangesAsync();
            }
        }
    }
}

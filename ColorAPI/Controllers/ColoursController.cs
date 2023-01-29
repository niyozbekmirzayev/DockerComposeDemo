using ColorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ColoursController : ControllerBase
    {
        private readonly ColourDbContext _dbContext;
        public ColoursController(ColourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetAllColours() 
        {
            return _dbContext.Colours;
        }
    }
}
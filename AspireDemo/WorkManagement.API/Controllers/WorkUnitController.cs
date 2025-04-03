using Microsoft.AspNetCore.Mvc;

namespace WorkManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkUnitController : ControllerBase
    {
        private readonly ILogger<WorkUnitController> _logger;

        private readonly AppDbContext _appDbContext;

        public WorkUnitController(ILogger<WorkUnitController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _appDbContext = dbContext;
        }

        [HttpPost(Name = "Post work unit")]
        public IActionResult PostWork([FromBody] WorkUnitDto workUnitDto)
        {
            WorkUnit workUnit = new WorkUnit() { Text = workUnitDto.Text };

            _appDbContext.WorkUnits.Add(workUnit);

            _appDbContext.SaveChanges();

            return new OkResult();
        }
    }
}

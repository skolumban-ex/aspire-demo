using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace WorkManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkUnitController : ControllerBase
    {
        private readonly ILogger<WorkUnitController> _logger;

        private readonly AppDbContext _appDbContext;

        private readonly WorkerApiClient _workerClient;

        public WorkUnitController(ILogger<WorkUnitController> logger, AppDbContext dbContext, WorkerApiClient workerClient)
        {
            _logger = logger;
            _appDbContext = dbContext;
            _workerClient = workerClient;
        }

        [HttpPost(Name = "Post work unit")]
        public IActionResult PostWork([FromBody] WorkUnitPostDto workUnitDto)
        {
            WorkUnit workUnit = PerformWork(workUnitDto);

            _appDbContext.WorkUnits.Add(workUnit);

            _appDbContext.SaveChanges();

            return new OkResult();
        }

        private WorkUnit PerformWork(WorkUnitPostDto workUnitDto)
        {
            WorkResult responseObject = _workerClient.GetWorkResult(workUnitDto);

            return new WorkUnit()
            {
                Text = responseObject.Text,
                StartCount = responseObject.StartCount,
                EndCount = responseObject.EndCount,
            };
        }

        

        [HttpGet(Name = "Get work units")]
        public IEnumerable<WorkUnit> Get()
        {
            return _appDbContext.WorkUnits.ToArray();
        }
    }


}

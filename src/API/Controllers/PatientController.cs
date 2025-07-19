namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<PatientEntity> _repository;

        public PatientController(IRepository<PatientEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet("Test")]
        public IActionResult Test_Status_Code()
        {
            return Ok("Code 200.");
        }
    }
}
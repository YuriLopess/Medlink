namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet("Test")]
        public IActionResult Test_Status_Code()
        {
            return Ok("Code 200.");
        }

    }
}

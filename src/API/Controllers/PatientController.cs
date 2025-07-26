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

        [HttpGet("Get")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<PatientEntity>> GetPatientById([FromHeader] Guid id)
        {
            var response = await _repository.Get(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<List<PatientEntity>>> GetAllPatient()
        {
            var response = await _repository.GetAll();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Post")]
        [ProducesResponseType(typeof(PatientEntity), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<PatientEntity>> PostPatient(PatientEntity patient)
        {
            _repository.Add(patient);

            return Ok(patient);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(PatientEntity), 200 )]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<PatientEntity>> DeletePatient(PatientEntity patient)
        {
            _repository.Delete(patient);

            return Ok(patient);
        }

        [HttpPut("Put")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<PatientEntity>> PutPatient(PatientEntity patient)
        {
            throw new NotImplementedException();
        }
    }
}
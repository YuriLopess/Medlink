namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IMapper mapper, IPatientService patientService, ILogger<PatientController> logger)
        {
            _mapper = mapper;
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> GetPatientById([FromHeader] Guid id)
        {
            _logger.LogInformation("Received request to get patient by ID: {Id}", id);

            var response = await _patientService.GetPatientById(id);

            if (!response.Status)
            {
                _logger.LogWarning("Patient with ID {Id} not found.", id);
            }
            else
            {
                _logger.LogInformation("Patient with ID {Id} retrieved successfully.", id);
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<PatientEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<List<PatientEntity>>>> GetAllPatient()
        {
            _logger.LogInformation("Received request to get all patients.");

            var response = await _patientService.GetAllPatients();

            _logger.LogInformation("Returned {Count} patients.", response.Data?.Count ?? 0);

            return Ok(response);
        }

        [HttpPost("Post")]
        [ProducesResponseType(typeof(PatientEntity), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> PostPatient([FromBody] PatientDto patientDto)
        {
            _logger.LogInformation("Received request to create a new patient.");

            var patient = _mapper.Map<PatientEntity>(patientDto);
            var response = await _patientService.SavePatient(patient);

            if (!response.Status)
            {
                _logger.LogError("Failed to create patient. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Patient created successfully with ID: {Id}", patient.Id);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> DeletePatient([FromBody] PatientDto patientDto)
        {
            _logger.LogInformation("Received request to delete a patient.");

            var patient = _mapper.Map<PatientEntity>(patientDto);
            var response = await _patientService.DeletePatient(patient);

            if (!response.Status)
            {
                _logger.LogError("Failed to delete patient. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Patient deleted successfully with ID: {Id}", patient.Id);
            return Ok(response);
        }

        [HttpPut("Put")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> PutPatient([FromBody] PatientDto patientDto)
        {
            _logger.LogInformation("Received request to update patient.");

            var patient = _mapper.Map<PatientEntity>(patientDto);
            var response = await _patientService.UpdatePatient(patient);

            if (!response.Status)
            {
                _logger.LogError("Failed to update patient. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Patient updated successfully with ID: {Id}", patient.Id);
            return Ok(response);
        }
    }
}
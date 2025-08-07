namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IMapper mapper, IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _mapper = mapper;
            _doctorService = doctorService;
            _logger = logger;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(DoctorEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<DoctorEntity>>> GetDoctorById([FromHeader] Guid id)
        {
            _logger.LogInformation("Received request to get doctor by ID: {Id}", id);

            var response = await _doctorService.GetDoctorById(id);

            if (!response.Status)
            {
                _logger.LogWarning("Doctor with ID {Id} not found.", id);
            }
            else
            {
                _logger.LogInformation("Doctor with ID {Id} retrieved successfully.", id);
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<DoctorEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<List<DoctorEntity>>>> GetAllDoctors()
        {
            _logger.LogInformation("Received request to get all doctors.");

            var response = await _doctorService.GetAllDoctors();

            _logger.LogInformation("Returned {Count} doctors.", response.Data?.Count ?? 0);

            return Ok(response);
        }

        [HttpPost("Post")]
        [ProducesResponseType(typeof(DoctorEntity), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<DoctorEntity>>> PostDoctor([FromBody] DoctorDto doctorDto)
        {
            _logger.LogInformation("Received request to create a new doctor.");

            var doctor = _mapper.Map<DoctorEntity>(doctorDto);
            var response = await _doctorService.SaveDoctor(doctor);

            if (!response.Status)
            {
                _logger.LogError("Failed to create doctor. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Doctor created successfully with ID: {Id}", doctor.Id);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(DoctorEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<DoctorEntity>>> DeleteDoctor([FromBody] DoctorDto doctorDto)
        {
            _logger.LogInformation("Received request to delete a doctor.");

            var doctor = _mapper.Map<DoctorEntity>(doctorDto);
            var response = await _doctorService.DeleteDoctor(doctor);

            if (!response.Status)
            {
                _logger.LogError("Failed to delete doctor. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Doctor deleted successfully with ID: {Id}", doctor.Id);
            return Ok(response);
        }

        [HttpPut("Put")]
        [ProducesResponseType(typeof(DoctorEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<DoctorEntity>>> PutDoctor([FromBody] DoctorDto doctorDto)
        {
            _logger.LogInformation("Received request to update doctor.");

            var doctor = _mapper.Map<DoctorEntity>(doctorDto);
            var response = await _doctorService.UpdateDoctor(doctor);

            if (!response.Status)
            {
                _logger.LogError("Failed to update doctor. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Doctor updated successfully with ID: {Id}", doctor.Id);
            return Ok(response);
        }
    }
}
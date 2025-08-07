using Domain.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IMapper mapper, IAppointmentServices appointmentService, ILogger<AppointmentController> logger)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _logger = logger;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(AppointmentEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<AppointmentEntity>>> GetAppointmentById([FromHeader] Guid id)
        {
            _logger.LogInformation("Received request to get appointment by ID: {Id}", id);

            var response = await _appointmentService.GetAppointmentById(id);

            if (!response.Status)
            {
                _logger.LogWarning("Appointment with ID {Id} not found.", id);
            }
            else
            {
                _logger.LogInformation("Appointment with ID {Id} retrieved successfully.", id);
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<AppointmentEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<List<AppointmentEntity>>>> GetAllAppointments()
        {
            _logger.LogInformation("Received request to get all appointments.");

            var response = await _appointmentService.GetAllAppointments();

            _logger.LogInformation("Returned {Count} appointments.", response.Data?.Count ?? 0);

            return Ok(response);
        }

        [HttpPost("Post")]
        [ProducesResponseType(typeof(AppointmentEntity), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<AppointmentEntity>>> PostAppointment([FromBody] AppointmentDto appointmentDto)
        {
            _logger.LogInformation("Received request to create a new appointment.");

            var appointment = _mapper.Map<AppointmentEntity>(appointmentDto);
            var response = await _appointmentService.SaveAppointment(appointment);

            if (!response.Status)
            {
                _logger.LogError("Failed to create appointment. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Appointment created successfully with ID: {Id}", appointment.Id);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(AppointmentEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<AppointmentEntity>>> DeleteAppointment([FromBody] AppointmentDto appointmentDto)
        {
            _logger.LogInformation("Received request to delete an appointment.");

            var appointment = _mapper.Map<AppointmentEntity>(appointmentDto);
            var response = await _appointmentService.DeleteAppointment(appointment);

            if (!response.Status)
            {
                _logger.LogError("Failed to delete appointment. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Appointment deleted successfully with ID: {Id}", appointment.Id);
            return Ok(response);
        }

        [HttpPut("Put")]
        [ProducesResponseType(typeof(AppointmentEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<AppointmentEntity>>> PutAppointment([FromBody] AppointmentDto appointmentDto)
        {
            _logger.LogInformation("Received request to update appointment.");

            var appointment = _mapper.Map<AppointmentEntity>(appointmentDto);
            var response = await _appointmentService.UpdateAppointment(appointment);

            if (!response.Status)
            {
                _logger.LogError("Failed to update appointment. Error: {Error}", response.Message);
                return StatusCode(500, response);
            }

            _logger.LogInformation("Appointment updated successfully with ID: {Id}", appointment.Id);
            return Ok(response);
        }
    }
}
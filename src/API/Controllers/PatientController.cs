using MedLink.Application.DTOs;

using Domain.Entities;
using MedLink.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<PatientEntity> _repository;
        private readonly IMapper _mapper;  

        public PatientController(IRepository<PatientEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> GetPatientById([FromHeader] Guid id)
        {
            var response = await _repository.Get(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<PatientEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<List<PatientEntity>>>> GetAllPatient()
        {
            var response = await _repository.GetAll();

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("Post")]
        [ProducesResponseType(typeof(PatientEntity), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> PostPatient([FromBody] PatientDto patientDto)
        {
            var patient = _mapper.Map<PatientEntity>(patientDto);
            await _repository.Add(patient);

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> DeletePatient([FromBody] PatientDto patientDto)
        {
            var patient = _mapper.Map<PatientEntity>(patientDto);

            await _repository.Delete(patient);

            return Ok(patient);
        }

        [HttpPut("Put")]
        [ProducesResponseType(typeof(PatientEntity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult<ResponseEntity<PatientEntity>>> PutPatient([FromBody] PatientDto patientDto)
        {
            var patient = _mapper.Map<PatientEntity>(patientDto);

            await _repository.Update(patient);

            return Ok(patient);
        }
    }
}
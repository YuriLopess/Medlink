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

        [HttpPost("add")]
        public async Task<IActionResult> AddPatient()
        {
            var newPatient = new PatientEntity
            {
                Id = Guid.NewGuid(),
                Name = "Maria Teste",
                Email = "maria.teste@email.com",
                Cpf = "12345678900",
                BithDate = new DateTime(1995, 5, 15)
            };

            await _repository.Add(newPatient);

            return Ok("Paciente cadastrado com sucesso.");
        }

        [HttpGet("Test")]
        public IActionResult Test_Status_Code()
        {
            return Ok("Code 200.");
        }
    }
}
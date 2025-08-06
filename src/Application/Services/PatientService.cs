using MedLink.Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<PatientEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IAppointmentUseCase _appointmentUseCase;

        public PatientService(IRepository<PatientEntity> repository, IMapper mapper, IAppointmentUseCase appointmentUseCase)
        {
            _appointmentUseCase = appointmentUseCase;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<PatientEntity>> DeletePatient(PatientEntity patient)
        {
            var data = new ResponseEntity<PatientEntity>();

            try
            {
                await _repository.Delete(patient);

                data.Message = "Patient deleted successfully.";
                data.Data = patient;
                data.Status = true;
                return data;
            }
            catch (Exception ex)
            {
                data.Message = $"An error occurred: {ex.Message}";
                data.Status = false;
                return data;
            }
        }


        public async Task<ResponseEntity<List<PatientEntity>>> GetAllPatients()
        {
            var data = new ResponseEntity<List<PatientEntity>>();

            try
            {
                var responseData = await _repository.GetAll();

                if (responseData == null || !responseData.Any())
                {
                    data.Message = "No patients found.";
                    data.Status = false;
                    return data;
                }

                data.Message = "Patients retrieved successfully.";
                data.Data = responseData;
                data.Status = true;
                return data;
            }
            catch (Exception ex)
            {
                data.Message = $"An error occurred: {ex.Message}";
                data.Status = false;
                return data;
            }
        }

        public async Task<ResponseEntity<PatientEntity>> GetPatientById(Guid id)
        {
            var data = new ResponseEntity<PatientEntity>();
            
            try
            {
                var responseData = await _repository.Get(id);

                if (responseData == null)
                {
                    data.Message = "Patient not found.";
                    data.Status = false;
                    return data;
                }

                data.Message = "Patient retrieved successfully.";
                data.Data = responseData;
                data.Status = true;
                return data;
            }
            catch (Exception ex)
            {
                data.Message = $"An error occurred: {ex.Message}";
                data.Status = false;
                return data;
            }
        }

        public async Task<ResponseEntity<PatientEntity>> SavePatient(PatientEntity patient)
        {
            var data = new ResponseEntity<PatientEntity>();

            try
            {
                if (patient.Id == Guid.Empty)
                    patient.Id = Guid.NewGuid();

                await _repository.Add(patient);

                data.Message = "Patient created successfully.";
                data.Data = patient;
                data.Status = true;
                return data;
            }
            catch (Exception ex)
            {
                data.Message = $"An error occurred: {ex.Message}";
                data.Status = false;
                return data;
            }
        }

        public async Task<ResponseEntity<PatientEntity>> UpdatePatient(PatientEntity patient)
        {
            var data = new ResponseEntity<PatientEntity>();

            try
            {
                await _repository.Update(patient);

                data.Message = "Patient updated successfully.";
                data.Data = patient;
                data.Status = true;

                return data;
            }
            catch (Exception ex)
            {
                data.Message = $"An error occurred: {ex.Message}";
                data.Status = false;

                return data;
            }
        }
    }
}
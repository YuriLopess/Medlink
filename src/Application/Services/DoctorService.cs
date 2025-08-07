using MedLink.Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<DoctorEntity> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IRepository<DoctorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<DoctorEntity>> GetDoctorById(Guid id)
        {
            var response = new ResponseEntity<DoctorEntity>();

            try
            {
                var data = await _repository.Get(id);
                if (data == null)
                {
                    response.Status = false;
                    response.Message = "Doctor not found.";
                    return response;
                }

                response.Status = true;
                response.Data = data;
                response.Message = "Doctor retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<List<DoctorEntity>>> GetAllDoctors()
        {
            var response = new ResponseEntity<List<DoctorEntity>>();

            try
            {
                var data = await _repository.GetAll();
                if (data == null || !data.Any())
                {
                    response.Status = false;
                    response.Message = "No doctors found.";
                    return response;
                }

                response.Status = true;
                response.Data = data;
                response.Message = "Doctors retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<DoctorEntity>> SaveDoctor(DoctorEntity doctor)
        {
            var response = new ResponseEntity<DoctorEntity>();

            try
            {
                if (doctor.Id == Guid.Empty)
                    doctor.Id = Guid.NewGuid();

                await _repository.Add(doctor);

                response.Status = true;
                response.Data = doctor;
                response.Message = "Doctor created successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<DoctorEntity>> UpdateDoctor(DoctorEntity doctor)
        {
            var response = new ResponseEntity<DoctorEntity>();

            try
            {
                await _repository.Update(doctor);

                response.Status = true;
                response.Data = doctor;
                response.Message = "Doctor updated successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<DoctorEntity>> DeleteDoctor(DoctorEntity doctor)
        {
            var response = new ResponseEntity<DoctorEntity>();

            try
            {
                await _repository.Delete(doctor);

                response.Status = true;
                response.Data = doctor;
                response.Message = "Doctor deleted successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }
    }
}
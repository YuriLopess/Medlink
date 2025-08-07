using MedLink.Domain.Interfaces.Repositories;

namespace MedLink.Application.Services
{
    public class AppointmentService : IAppointmentServices
    {
        private readonly IRepository<AppointmentEntity> _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IRepository<AppointmentEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<AppointmentEntity>> GetAppointmentById(Guid id)
        {
            var response = new ResponseEntity<AppointmentEntity>();

            try
            {
                var data = await _repository.Get(id);
                if (data == null)
                {
                    response.Status = false;
                    response.Message = "Appointment not found.";
                    return response;
                }

                response.Status = true;
                response.Data = data;
                response.Message = "Appointment retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<List<AppointmentEntity>>> GetAllAppointments()
        {
            var response = new ResponseEntity<List<AppointmentEntity>>();

            try
            {
                var data = await _repository.GetAll();
                if (data == null || !data.Any())
                {
                    response.Status = false;
                    response.Message = "No appointments found.";
                    return response;
                }

                response.Status = true;
                response.Data = data;
                response.Message = "Appointments retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<AppointmentEntity>> SaveAppointment(AppointmentEntity appointment)
        {
            var response = new ResponseEntity<AppointmentEntity>();

            try
            {
                if (appointment.Id == Guid.Empty)
                    appointment.Id = Guid.NewGuid();

                await _repository.Add(appointment);

                response.Status = true;
                response.Data = appointment;
                response.Message = "Appointment created successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<AppointmentEntity>> UpdateAppointment(AppointmentEntity appointment)
        {
            var response = new ResponseEntity<AppointmentEntity>();

            try
            {
                await _repository.Update(appointment);

                response.Status = true;
                response.Data = appointment;
                response.Message = "Appointment updated successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseEntity<AppointmentEntity>> DeleteAppointment(AppointmentEntity appointment)
        {
            var response = new ResponseEntity<AppointmentEntity>();

            try
            {
                await _repository.Delete(appointment);

                response.Status = true;
                response.Data = appointment;
                response.Message = "Appointment deleted successfully.";
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
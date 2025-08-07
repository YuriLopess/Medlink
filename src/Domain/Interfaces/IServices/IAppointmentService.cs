namespace Domain.Interfaces.Services
{
    public interface IAppointmentServices
    {
        Task<ResponseEntity<AppointmentEntity>> GetAppointmentById(Guid id);
        Task<ResponseEntity<List<AppointmentEntity>>> GetAllAppointments();
        Task<ResponseEntity<AppointmentEntity>> SaveAppointment(AppointmentEntity appointment);
        Task<ResponseEntity<AppointmentEntity>> UpdateAppointment(AppointmentEntity appointment);
        Task<ResponseEntity<AppointmentEntity>> DeleteAppointment(AppointmentEntity appointment);
    }
}

namespace Domain.Interfaces.Services
{
    public interface IAppoitmentServices
    {
        public void ScheduleAnAppointmentEntity(AppointmentEntity AppointmentEntity);
        public void cancelAnAppointmentEntity(AppointmentEntity AppointmentEntity);

    }
}

namespace Domain.Interfaces.IUseCases
{
    public interface IAppointmentUseCase
    {
        public void ScheduleAnAppointmentEntity(AppointmentEntity AppointmentEntity);
        public void cancelAnAppointmentEntity(AppointmentEntity AppointmentEntity);
    }
}

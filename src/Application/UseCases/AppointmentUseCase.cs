namespace Application.UseCases
{
    public class AppointmentUseCase : IAppointmentUseCase
    {
        public void cancelAnAppointmentEntity(AppointmentEntity appointment)
        {
            if (appointment.DateTime >= DateTime.Now)
            {
                throw new DomainException("An appointment cannot be canceled after its time.");
            }
        }

        public void ScheduleAnAppointmentEntity(AppointmentEntity appointment)
        {
            //foreach (AppointmentEntity appointmentSaved in appointment.Doctor.appointments)
            //{
            //    if (appointmentSaved.DateTime == appointment.DateTime)
            //    {
            //        throw new DomainException("The doctor already has a an appointment scheduled at this time.");
            //    }
            //}

            //var hoursDifference = DateTime.Now - appointment.DateTime;

            //if (hoursDifference.TotalHours <= 24)
            //{
            //    throw new DomainException("An appointment must be scheduled more than 24 hours in advance.");
            //}

            throw new NotImplementedException();
        }
    }
}

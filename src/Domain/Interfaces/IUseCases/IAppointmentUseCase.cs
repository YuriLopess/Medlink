using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUseCases
{
    public interface IAppointmentUseCase
    {
        public void ScheduleAnAppointmentEntity(AppointmentEntity AppointmentEntity);
        public void cancelAnAppointmentEntity(AppointmentEntity AppointmentEntity);
    }
}

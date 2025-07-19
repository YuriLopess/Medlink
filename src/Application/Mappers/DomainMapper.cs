namespace MedLink.Application.Mappers
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<AppointmentEntity, AppointmentDto>();
            CreateMap<DoctorEntity, DoctorDto>();
            CreateMap<PatientEntity, PatientDto>();
        }
    }
}

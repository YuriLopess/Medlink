namespace MedLink.Application.Mappers
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<AppointmentEntity, AppointmentDto>().ReverseMap();
            CreateMap<DoctorEntity, DoctorDto>().ReverseMap();
            CreateMap<PatientEntity, PatientDto>().ReverseMap();
        }
    }
}
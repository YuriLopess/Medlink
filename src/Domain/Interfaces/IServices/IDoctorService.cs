namespace Domain.Interfaces.IServices
{
    public interface IDoctorService
    {
        Task<ResponseEntity<DoctorEntity>> GetDoctorById(Guid id);
        Task<ResponseEntity<List<DoctorEntity>>> GetAllDoctors();
        Task<ResponseEntity<DoctorEntity>> SaveDoctor(DoctorEntity doctor);
        Task<ResponseEntity<DoctorEntity>> UpdateDoctor(DoctorEntity doctor);
        Task<ResponseEntity<DoctorEntity>> DeleteDoctor(DoctorEntity doctor);
    }
}
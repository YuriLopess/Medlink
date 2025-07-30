namespace Domain.Interfaces.IServices
{
    public interface IPatientService
    {
        public Task<ResponseEntity<PatientEntity>> GetPatientById(Guid id);
        public Task<ResponseEntity<List<PatientEntity>>> GetAllPatients();
        public Task<ResponseEntity<PatientEntity>> SavePatient(PatientEntity patient);
        public Task<ResponseEntity<PatientEntity>> DeletePatient(PatientEntity patient);
        public Task<ResponseEntity<PatientEntity>> UpdatePatient(PatientEntity patient);    
    }
}
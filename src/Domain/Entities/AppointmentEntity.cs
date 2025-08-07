namespace Domain.Entities
{
    public class AppointmentEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateTime { get; set; }
        public Status Status { get; set; }
        public Guid DoctorEntityId { get; set; }
        public Guid PatientEntityId { get; set; }
        public DateTime CreatedDate { get; init; } = DateTime.Now;
    }
}

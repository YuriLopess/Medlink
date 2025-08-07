namespace Domain.Entities
{
    public class DoctorEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Specialty { get; set; }
        public string? Crm { get; set; }

    }
}

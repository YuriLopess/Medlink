namespace Domain.Entities
{
    public class PatientEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

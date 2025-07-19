namespace MedLink.Application.DTOs
{
    public class AppointmentDto
    {
        string Title { get; set; }
        DateTime DateTime { get; set; }
        Status Status { get; set; }
        DoctorEntity Doctor { get; set; }
        PatientEntity Patient { get; set; }
    }
}

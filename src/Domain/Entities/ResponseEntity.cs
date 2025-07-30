namespace Domain.Entities
{
    public class ResponseEntity<Response>
    {
        public Response Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}

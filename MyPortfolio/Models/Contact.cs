namespace MyPortfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool IsRead { get; set; }
        public string? ResponseMessage { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}

namespace MyPortfolio.Models
{
    public class ExperienceHighlight
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public Experience Experience { get; set; }
    }
}

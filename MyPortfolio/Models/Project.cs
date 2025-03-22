using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Url]
        public string? GitHubUrl { get; set; }
        [Url]
        public string? LiveUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        // Navigation properties
        public ICollection<ProjectSkill>? ProjectSkills { get; set; }
        public ICollection<ProjectImage>? ProjectImages { get; set; }
        public bool IsFeatured { get; internal set; }
        

        
    }
}

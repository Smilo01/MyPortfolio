
namespace MyPortfolio.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }  // e.g., Programming, Design, Tools
        public int ProficiencyLevel { get; set; }  // 1-5 scale
        public string IconUrl { get; set; }

        // Navigation property
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}

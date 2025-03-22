namespace MyPortfolio.Models
{
    public class ProjectSkill
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}

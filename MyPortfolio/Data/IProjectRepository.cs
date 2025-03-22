using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        // Project-specific methods
        Task<Project> GetProjectWithDetailsAsync(int id);
        Task<IEnumerable<Project>> GetProjectsBySkillAsync(int skillId);
    }
}

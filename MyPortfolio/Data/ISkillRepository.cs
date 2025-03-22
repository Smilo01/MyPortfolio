using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetSkillsByIdAsync(int id);
    }
}


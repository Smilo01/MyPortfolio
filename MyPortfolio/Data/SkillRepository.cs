using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(MyPortfolioDbContext context) : base(context) { }

        public async Task<IEnumerable<Skill>> GetSkillsByIdAsync(int id)
        {
            return await _context.Skills
                .Where(s => s.Id == id)
                .OrderByDescending(s => s.ProficiencyLevel)
                .ToListAsync();
        }
    }
}

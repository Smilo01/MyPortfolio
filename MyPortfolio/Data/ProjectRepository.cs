using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class ProjectRepository : BaseRepository<Project> , IProjectRepository  
    {
        public ProjectRepository(MyPortfolioDbContext context) : base(context) { }

        public async Task<Project> GetProjectWithDetailsAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.ProjectSkills)
                    .ThenInclude(ps => ps.Skill)
                .Include(p => p.ProjectImages)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsBySkillAsync(int skillId)
        {
            return await _context.Projects
                .Include(p => p.ProjectSkills)
                .Where(p => p.ProjectSkills.Any(ps => ps.SkillId == skillId))
                .ToListAsync();
        }
    }
}

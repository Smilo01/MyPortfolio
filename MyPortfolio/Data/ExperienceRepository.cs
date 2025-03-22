using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class ExperienceRepository : BaseRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(MyPortfolioDbContext context) : base(context) { }

        public async Task<Experience> GetExperienceWithHighlightsAsync(int id)
        {
            return await _context.Experience
                .Include(e => e.Highlights.OrderBy(h => h.DisplayOrder))
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

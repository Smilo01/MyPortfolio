using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        public EducationRepository(MyPortfolioDbContext context) : base(context) { }

        public async Task<IEnumerable<Education>> GetEducationByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Education
                .Where(e => e.StartDate >= startDate && (e.CompletionDate <= endDate || !e.CompletionDate.HasValue))
                .OrderByDescending(e => e.StartDate)
                .ToListAsync();
        }
    }
}

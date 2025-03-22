using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class ProjectImageRepository : BaseRepository<ProjectImage> , IProjectImageRepository
    {
        public ProjectImageRepository(MyPortfolioDbContext context) : base(context) { }
        public async Task<IEnumerable<ProjectImage>> GetProjectImagesAsync(int id)
        {

            return await _context.ProjectImages
                .Where(p => p.Id == id).ToListAsync();
        }
    }
}

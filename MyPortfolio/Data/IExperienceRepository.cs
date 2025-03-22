using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface IExperienceRepository : IBaseRepository<Experience>
    {
        Task<Experience> GetExperienceWithHighlightsAsync(int id);
    }
}

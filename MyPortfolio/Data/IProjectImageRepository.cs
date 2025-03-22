using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface IProjectImageRepository : IBaseRepository<ProjectImage>
    {
        Task<IEnumerable<ProjectImage>> GetProjectImagesAsync(int id);
    }
}

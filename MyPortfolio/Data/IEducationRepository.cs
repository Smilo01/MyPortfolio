using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> GetEducationByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

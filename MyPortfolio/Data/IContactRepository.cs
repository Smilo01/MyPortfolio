using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetUnreadContactsAsync();
    }
}

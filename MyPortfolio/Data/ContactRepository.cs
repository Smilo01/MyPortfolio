using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(MyPortfolioDbContext context) : base(context) { }

        public async Task<IEnumerable<Contact>> GetUnreadContactsAsync()
        {
            return await _context.Contacts
                .Where(c => !c.IsRead)
                .OrderByDescending(c => c.SubmissionDate)
                .ToListAsync();
        }
    }
}

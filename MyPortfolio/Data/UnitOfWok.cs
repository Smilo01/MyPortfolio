namespace MyPortfolio.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPortfolioDbContext _context;
        private IProjectRepository _projectRepository;
        private ISkillRepository _skillRepository;
        private IEducationRepository _educationRepository;
        private IExperienceRepository _experienceRepository;
        private IContactRepository _contactRepository;
        private IProjectImageRepository _projectImageRepository;

        public UnitOfWork(MyPortfolioDbContext context)
        {
            _context = context;
        }

        public IProjectRepository Projects =>
            _projectRepository ??= new ProjectRepository(_context);

        public ISkillRepository Skills =>
            _skillRepository ??= new SkillRepository(_context);

        public IEducationRepository Education =>
            _educationRepository ??= new EducationRepository(_context);

        public IExperienceRepository Experience =>
            _experienceRepository ??= new ExperienceRepository(_context);

        public IContactRepository Contacts =>
            _contactRepository ??= new ContactRepository(_context);
        public IProjectImageRepository ProjectImages => _projectImageRepository ??= new ProjectImageRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

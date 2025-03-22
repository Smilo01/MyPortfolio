namespace MyPortfolio.Data
{
    public interface IUnitOfWork : IDisposable
    {
       // IBaseRepository Base { get; }
        IProjectRepository Projects { get; }
        ISkillRepository Skills { get; }
        IEducationRepository Education { get; }
        IExperienceRepository Experience { get; }
        IContactRepository Contacts { get; }
        IProjectImageRepository ProjectImages { get; }
        Task<int> SaveChangesAsync();
    }

}

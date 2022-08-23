using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<Project> GetDetailsByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
    }
}

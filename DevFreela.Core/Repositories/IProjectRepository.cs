using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Models;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<PaginationResult<Project>> GetAllAsync(string query, int page = 1);
        Task<Project> GetByIdAsync(int id);
        Task<Project> GetDetailsByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
    }
}

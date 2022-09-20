using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasks.Domain;

namespace MyTasks.Application.Interfaces
{
    public interface IMyTasksDbContext
    {
        DbSet<MyTask> MyTasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

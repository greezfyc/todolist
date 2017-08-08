using Git.Todolist.Data;
using Git.Todolist.Domain.Entity;
using Git.Todolist.Domain.IRepository;

namespace Git.Todolist.Repository
{
    public class LogRepository : RepositoryBase<LogEntity>, ILogRepository
    {
    }
}
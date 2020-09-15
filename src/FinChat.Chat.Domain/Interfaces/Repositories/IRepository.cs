using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinChat.Chat.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity: class
    {
        IEnumerable<TEntity> All();
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
    }
}
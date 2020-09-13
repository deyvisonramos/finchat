using System.Threading.Tasks;

namespace FinChat.Chat.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);
    }
}
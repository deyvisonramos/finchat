using System.Threading.Tasks;
using FinChat.Chat.Data.Context;

namespace FinChat.Chat.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinChatDbContext _context;

        public UnitOfWork(FinChatDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

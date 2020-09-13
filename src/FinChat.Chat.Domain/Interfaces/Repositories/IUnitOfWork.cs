using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinChat.Chat.Data.Transactions
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}

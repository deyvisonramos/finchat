using System.Collections.Generic;

namespace FinChat.Chat.Web.Transformers.Interfaces
{
    public interface ITransformer<TIn, TOut> 
        where TIn: class
        where TOut : class
    {
        TOut Transform(TIn @in);
        IEnumerable<TOut> Transform(IEnumerable<TIn> @in);
    }
}
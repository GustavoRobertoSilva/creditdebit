using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditDebit.Services
{
    public interface IDataStore<T>
    {
       
        //TODO Gustavo

        Task<bool> AddMovimentacaoAsync(T movimentacao);
        Task<bool> UpdateMovimentacaoAsync(T movimentacao);
        Task<bool> DeleteMovimentacaoAsync(string id);
        Task<T> GetMovimentacaoAsync(string id);
        Task<IEnumerable<T>> GetMovimentacoesAsync(bool forceRefresh = false);
    }
}

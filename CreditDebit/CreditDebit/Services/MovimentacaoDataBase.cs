using CreditDebit.Models;
using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace CreditDebit.Services
{
    class MovimentacaoDataBase
    {

        readonly SQLiteAsyncConnection database;

        public MovimentacaoDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Movimentacao>().Wait();
        }

        public Task<List<Movimentacao>> GetItemsAsync()
        {
            return database.Table<Movimentacao>().ToListAsync();
        }

        public Task<Movimentacao> GetMovimentacaoAsync(String id)
        {
            return database.Table<Movimentacao>().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();

        }

        public Task<int> SaveMovimentacaoAsync(Movimentacao movimentacao)
        {
            if (movimentacao.Id == null)
            {
                return database.InsertAsync(movimentacao);
            }

            return database.UpdateAsync(movimentacao);
        }

        public Task<int> DeleteMovimentacaoAsync(Movimentacao movimentacao)
        {
            return database.DeleteAsync(movimentacao);
        }

    }
}

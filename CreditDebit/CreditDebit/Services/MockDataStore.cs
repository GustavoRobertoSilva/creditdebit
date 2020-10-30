using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditDebit.Models;

namespace CreditDebit.Services
{
    public class MockDataStore : IDataStore<Movimentacao>
    {
        readonly List<Movimentacao> movimentacoes;

        public MockDataStore()
        {
            movimentacoes = new List<Movimentacao>()
            {
                new Movimentacao { Id = Guid.NewGuid().ToString(), Descricao = "Gasto Combustivel", Valor=100, Tipo="D"  },
                new Movimentacao { Id = Guid.NewGuid().ToString(), Descricao = "Salario", Valor=100, Tipo="C"  },
                new Movimentacao { Id = Guid.NewGuid().ToString(), Descricao = "Restaurante", Valor=54, Tipo="Débito"  },
            };
        }

        public async Task<bool> AddMovimentacaoAsync(Movimentacao item)
        {
            movimentacoes.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMovimentacaoAsync(Movimentacao movimentacao)
        {
            var oldItem = movimentacoes.Where((Movimentacao arg) => arg.Id == movimentacao.Id).FirstOrDefault();
            movimentacoes.Remove(oldItem);
            movimentacoes.Add(movimentacao);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMovimentacaoAsync(string id)
        {
            var oldItem = movimentacoes.Where((Movimentacao arg) => arg.Id == id).FirstOrDefault();
            movimentacoes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movimentacao> GetMovimentacaoAsync(string id)
        {
            return await Task.FromResult(movimentacoes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movimentacao>> GetMovimentacoesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(movimentacoes);
        }
    }
}
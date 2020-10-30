using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CreditDebit.Models;
using Xamarin.Forms;

namespace CreditDebit.ViewModels
{
    [QueryProperty(nameof(MovimentacaoId), nameof(MovimentacaoId))]
    public class MovimentacaoDetailViewModel : BaseViewModel
    {

        private string movimentacaoId;
        private DateTime data;
        private string descricao;
        private string tipo;
        public decimal valor;
        private string Id { get; set; }


        public MovimentacaoDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
            
        }

        public string Descricao
        {
            get => descricao;
            set => SetProperty(ref descricao, value);
        }

        public DateTime Data
        {
            get => data;
            set => SetProperty(ref data, value);
        }


        public string Tipo
        {
            get => tipo;
            set => SetProperty(ref tipo, value);
        }

        public decimal Valor
        {
            get => valor;
            set => SetProperty(ref valor, value);
        }

        public string MovimentacaoId
        {
            get
            {
                return movimentacaoId;
            }
            set
            {
                movimentacaoId = value;
                LoadMovimentacaoId(value);
            }
        }

        public Command DeleteCommand { get; }

        public async void LoadMovimentacaoId(string movimentacaoId)
        {
            try
            {
                var movimentacao = await DataStore.GetMovimentacaoAsync(movimentacaoId);
                Id = movimentacao.Id;
                Tipo = movimentacao.Tipo;
                Descricao = movimentacao.Descricao;
                Data = movimentacao.Data;
                Valor = movimentacao.Valor;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Movimentacao");
            }
        }

        private async void OnDelete(){
            
            await DataStore.DeleteMovimentacaoAsync(Id);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

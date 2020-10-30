using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CreditDebit.Models;
using CreditDebit.Views;

namespace CreditDebit.ViewModels
{
    public class MovimentacoesViewModel : BaseViewModel
    {
        private Movimentacao _selectedMovimentacao;

        public ObservableCollection<Movimentacao> Movimentacoes { get; }
        public Command LoadMovimentacoesCommand { get; }
        public Command AddMovimentacaoCommand { get; }
        public Command<Movimentacao> MovimentacaoTapped { get; }

        public MovimentacoesViewModel()
        {
            Title = "Movimentações";
            Movimentacoes = new ObservableCollection<Movimentacao>();
            LoadMovimentacoesCommand = new Command(async () => await ExecuteLoadMovimentacoesCommand());

            MovimentacaoTapped = new Command<Movimentacao>(OnMovimentacaoSelected);

            AddMovimentacaoCommand = new Command(OnAddMovimentacao);
        }

        async Task ExecuteLoadMovimentacoesCommand()
        {
            IsBusy = true;

            try
            {
                Movimentacoes.Clear();
                var movimentacaoes = await DataStore.GetMovimentacoesAsync(true);
                foreach (var movimentacao in movimentacaoes)
                {
                    Movimentacoes.Add(movimentacao);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedMovimentacao = null;
        }

        public Movimentacao SelectedMovimentacao
        {
            get => _selectedMovimentacao;
            set
            {
                SetProperty(ref _selectedMovimentacao, value);
                OnMovimentacaoSelected(value);
            }
        }

        private async void OnAddMovimentacao(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMovimentacaoPage));
        }

        async void OnMovimentacaoSelected(Movimentacao movimentacao)
        {
            if (movimentacao == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MovimentacaoDetailPage)}?{nameof(MovimentacaoDetailViewModel.MovimentacaoId)}={movimentacao.Id}");
        }
    }
}
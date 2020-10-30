using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CreditDebit.Models;
using Xamarin.Forms;

namespace CreditDebit.ViewModels
{
    public class NewMovimentacaoViewModel : BaseViewModel
    {

		private DateTime data;		
        private string descricao;
		private string tipo;
		public decimal valor;

        public NewMovimentacaoViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(tipo)
                && !String.IsNullOrWhiteSpace(descricao);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Movimentacao newMovimentacao = new Movimentacao()
            {
                Id = Guid.NewGuid().ToString(),
                Descricao = Descricao,
                Tipo = Tipo,
				Valor = Valor,
				Data = Data,
				
            };

            await DataStore.AddMovimentacaoAsync(newMovimentacao);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

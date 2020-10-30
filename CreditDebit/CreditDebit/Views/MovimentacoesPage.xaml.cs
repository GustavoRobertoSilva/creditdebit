using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CreditDebit.Models;
using CreditDebit.Views;
using CreditDebit.ViewModels;

namespace CreditDebit.Views
{
    public partial class MovimentacoesPage : ContentPage
    {
        MovimentacoesViewModel _viewModel;

        public MovimentacoesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MovimentacoesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
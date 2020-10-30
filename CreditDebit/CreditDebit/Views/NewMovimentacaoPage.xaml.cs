using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CreditDebit.Models;
using CreditDebit.ViewModels;

namespace CreditDebit.Views
{
    public partial class NewMovimentacaoPage : ContentPage
    {
        public Movimentacao Movimentacao { get; set; }

        public DateTime MinDate = new DateTime(); 

        public NewMovimentacaoPage()
        {
            Title = "Home";
            InitializeComponent();
            BindingContext = new NewMovimentacaoViewModel();
        }
    }
}
using System;
using System.Collections.Generic;
using CreditDebit.ViewModels;
using CreditDebit.Views;
using Xamarin.Forms;

namespace CreditDebit
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MovimentacaoDetailPage), typeof(MovimentacaoDetailPage));
            Routing.RegisterRoute(nameof(NewMovimentacaoPage), typeof(NewMovimentacaoPage));

        }

    }
}

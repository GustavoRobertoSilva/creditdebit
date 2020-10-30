using System.ComponentModel;
using Xamarin.Forms;
using CreditDebit.ViewModels;

namespace CreditDebit.Views
{
    public partial class MovimentacaoDetailPage : ContentPage
    {
        public MovimentacaoDetailPage()
        {
            InitializeComponent();
            BindingContext = new MovimentacaoDetailViewModel();
        }
    }
}
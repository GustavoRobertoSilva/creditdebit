using System.ComponentModel;
using Xamarin.Forms;
using CreditDebit.ViewModels;

namespace CreditDebit.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
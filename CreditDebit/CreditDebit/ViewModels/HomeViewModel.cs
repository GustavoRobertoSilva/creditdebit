using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CreditDebit.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
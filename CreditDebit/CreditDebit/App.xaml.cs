using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CreditDebit.Services;
using CreditDebit.Views;

namespace CreditDebit
{
    public partial class App : Application
    {

        private static MovimentacaoDataBase database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        internal static MovimentacaoDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MovimentacaoDataBase(DependencyService.Get<IFileHelper>()
                        .GetLocalFilePath("movimentacao.db3"));
                }

                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

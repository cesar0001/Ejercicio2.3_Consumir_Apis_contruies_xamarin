using Consumo_Apis.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consumo_Apis
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Principal());
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

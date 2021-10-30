using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consumo_Apis.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        private async void btnapis_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnPais_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CountriesPage());
        }

        private async void btnFoursquare_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FourSquarePage());
        }
    }
}
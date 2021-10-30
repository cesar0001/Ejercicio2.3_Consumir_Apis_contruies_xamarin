using Consumo_Apis.Controles;
using Consumo_Apis.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumo_Apis
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnget_Clicked(object sender, EventArgs e)
        {
            


            

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                List<Personas> listaPersonas = new List<Personas>();


                listaPersonas = await PersonasControlador.GetPersonas();


                lstPersonas.ItemsSource = listaPersonas;
            }
            else
            {
                await DisplayAlert("error", "Sin internet", "ok");
            }

        }
    }
}

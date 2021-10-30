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
    public partial class Informacion : ContentPage
    {
        double latitud, longitud;
        
        public Informacion(string foto,string poblacion, string lenguaje, string capital, string lat, string lon)
        {
            InitializeComponent();
            this.img.Source = foto;
            this.plobacion.Text = "Poblacion: " + poblacion;
            this.lenguaje.Text = "Lenguaje: " +lenguaje;
            this.capital.Text = "Capital: "+ capital;
            latitud = Convert.ToDouble(lat);
            longitud = Convert.ToDouble(lon);
        }

        private async void btnmapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mapa(latitud,longitud,this.plobacion.Text,this.capital.Text));
        }
    }
}
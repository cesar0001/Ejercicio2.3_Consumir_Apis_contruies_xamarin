using Consumo_Apis.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Consumo_Apis.Modelos.Countries;

namespace Consumo_Apis.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : ContentPage
    {

        string lenguaje = "";
        public CountriesPage()
        {
            InitializeComponent();
            MainPicker.Items.Add("Americas");
            MainPicker.Items.Add("Africa");
            MainPicker.Items.Add("Asia");
            MainPicker.Items.Add("Europa");
            MainPicker.Items.Add("Oceania");
        }

    

        private async void lstPaises_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CountriesRest selected = e.SelectedItem as CountriesRest;
            if (selected == null)
                return;

            double lat = Convert.ToDouble(selected.latlng[0]);
            double lon = Convert.ToDouble(selected.latlng[1]);
            string foto = selected.flags.png;
            int poblacion = selected.population;
            string capital = selected.capital[0];

            lenguaje = "";
            validacionLenguaje(selected);


             
            await Navigation.PushAsync(new Informacion(foto, poblacion.ToString(), lenguaje, capital,
                lat.ToString(), lon.ToString()    ));

            //await DisplayAlert("Pais", lenguaje.ToString() + "", "ok");
        }

        private void lstPaises_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lstPaises.SelectedItem = null;
        }


        public void validacionLenguaje(CountriesRest selected)
        {
            if (String.IsNullOrWhiteSpace(selected.languages.fra) == false)
            {
                lenguaje = selected.languages.fra;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.hat) == false)
            {
                lenguaje = selected.languages.hat;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.eng) == false)
            {
                lenguaje = selected.languages.eng;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.spa) == false)
            {
                lenguaje = selected.languages.spa;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.aym) == false)
            {
                lenguaje = selected.languages.aym;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.grn) == false)
            {
                lenguaje = selected.languages.grn;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.que) == false)
            {
                lenguaje = selected.languages.que;
            }


            if (String.IsNullOrWhiteSpace(selected.languages.kal) == false)
            {
                lenguaje = selected.languages.kal;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.bjz) == false)
            {
                lenguaje = selected.languages.bjz;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.nld) == false)
            {
                lenguaje = selected.languages.nld;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.pap) == false)
            {
                lenguaje = selected.languages.pap;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.jam) == false)
            {
                lenguaje = selected.languages.jam;
            }

            if (String.IsNullOrWhiteSpace(selected.languages.por) == false)
            {
                lenguaje = selected.languages.por;
            }

        }

        private async void MainPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dato = MainPicker.Items[MainPicker.SelectedIndex];
            lstPaises.ItemsSource = null;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                if (dato.Equals("Europa") == true)
                {
                    dato = "Europe";
                }

                List<CountriesRest> listaPaise = new List<CountriesRest>();


                listaPaise = await PaisesControlador.GetCountries(dato);


                lstPaises.ItemsSource = listaPaise;
            }
            else
            {
                await DisplayAlert("error", "Sin internet", "ok");
            }


        }
    }
}
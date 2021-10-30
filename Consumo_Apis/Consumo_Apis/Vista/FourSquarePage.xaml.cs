using Consumo_Apis.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Consumo_Apis.Modelos.FourSquare;

namespace Consumo_Apis.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourSquarePage : ContentPage
    {
        CancellationTokenSource cts;

        public FourSquarePage()
        {
            InitializeComponent();
            
        }

        public async void cargarDatos()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {


                try
                {

                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    var location = await Geolocation.GetLocationAsync(request, cts.Token);


                    if (location != null)
                    {
                        //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        double latitud = location.Latitude;
                        double longitud = location.Longitude;



                        try
                        {

                            //mi ubicacion lat = 15.5028821, longitud = -88.016528

                            List<Modelos.FourSquare.Venue> sitioscercas = new List<Modelos.FourSquare.Venue>();

                            sitioscercas = await FourSquareControlador.GetListSites(latitud, longitud);

                            lstFourSquare.ItemsSource = sitioscercas;
                        }
                        catch (Exception )
                        {
                            await DisplayAlert("error", "Error al extraer datos", "ok");
                        }


                    }
                    



                }
                catch (FeatureNotSupportedException )
                {
                    await DisplayAlert("Error", "No tiene permisos de Ubicación", "Ok");
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException)
                {
                    await DisplayAlert("Error", "No tiene permisos de Ubicación", "Ok");
                    // Handle not enabled on device exception
                }
                catch (PermissionException)
                {
                    await DisplayAlert("Error", "No tiene permisos de Ubicación", "Ok");
                    // Handle permission exception
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "No tiene permisos de Ubicación", "Ok");
                    // Unable to get location
                }


                                 
            }
            else
            {
                await DisplayAlert("error", "Sin internet", "ok");
            }
        }

        private void lstFourSquare_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lstFourSquare.SelectedItem = null;
        }

        private void btnFour_Clicked(object sender, EventArgs e)
        {
            cargarDatos();
        }


        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }

    }



}
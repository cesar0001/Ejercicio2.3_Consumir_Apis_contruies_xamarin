using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Consumo_Apis.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        public Mapa(double lat, double lon, string des_corta, string des_larga)
        {
            InitializeComponent();
            Position position = new Position(lat, lon);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan);

            Pin pin = new Pin
            {
                Label = des_corta,
                Address = des_larga,
                Type = PinType.Place,
                Position = position
            };
            map.Pins.Add(pin);

            Content = map;

        }
    }
}
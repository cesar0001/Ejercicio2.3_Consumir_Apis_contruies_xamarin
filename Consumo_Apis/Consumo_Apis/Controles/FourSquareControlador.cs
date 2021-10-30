using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 

namespace Consumo_Apis.Controles
{
    public class FourSquareControlador
    {
        //public string client_id = "VJMKF4LTPUGX5LYESDTNFJ51TGFYO5GPHDHCN3UBR0PGKRHE";
        //public string client_secret = "PRXJ0FEJY3HBHCQBCIMBX0EJWRACCOXSRWWKYYU1SKPBXYZV";
        //public string four = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}"; 

        public async static Task<List<Modelos.FourSquare.Venue>> GetListSites( double latitud, double longitud )
        {

            List<Modelos.FourSquare.Venue> sitioscercas = new List<Modelos.FourSquare.Venue>();

            //string url = "https://api.foursquare.com/v2/venues/search?ll=15.5028978,-88.016503&client_id=VJMKF4LTPUGX5LYESDTNFJ51TGFYO5GPHDHCN3UBR0PGKRHE&client_secret=PRXJ0FEJY3HBHCQBCIMBX0EJWRACCOXSRWWKYYU1SKPBXYZV&v=20211025";

            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync(Controles.sitios.getUrl(latitud,longitud));

                if (respuesta.IsSuccessStatusCode)
                {
                    var json = respuesta.Content.ReadAsStringAsync().Result;

                    var lugares = JsonConvert.DeserializeObject<Modelos.FourSquare.VenuesRest>(json);

                    sitioscercas = lugares.response.venues as List<Modelos.FourSquare.Venue>;
                }

            }

 

            return sitioscercas;
        }

    }


}

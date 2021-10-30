using Consumo_Apis.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Consumo_Apis.Modelos.Countries;

namespace Consumo_Apis.Controles
{
    class PaisesControlador
    {
        //http://jsonviewer.stack.hu/
        //https://restcountries.com/v3.1/region/Americas

        public async static Task<List<CountriesRest>> GetCountries(string region)
        {

            List<CountriesRest> listaPaises = new List<CountriesRest>();

            string url = "https://restcountries.com/v3.1/region/" + region;

            using (HttpClient cliente = new HttpClient())
            {
                var response = await cliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;

                    listaPaises = JsonConvert.DeserializeObject<List<CountriesRest>>(contenido);
 
                     
                }

            }

            return listaPaises;
        }
    }
}

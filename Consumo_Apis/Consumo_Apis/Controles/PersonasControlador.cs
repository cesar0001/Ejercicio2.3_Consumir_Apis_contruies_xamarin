using Consumo_Apis.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Consumo_Apis.Controles
{
    public static class PersonasControlador
    {

        public async static Task<List<Personas>> GetPersonas()
        {

            List<Personas> listaPersonas = new List<Personas>();

            using (HttpClient cliente = new HttpClient())
            {
                var response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (response.IsSuccessStatusCode)
                {
                    var contenido =  response.Content.ReadAsStringAsync().Result;

                    listaPersonas  = JsonConvert.DeserializeObject<List<Personas>>(contenido);
                }

            }

            return listaPersonas;
        }

    }
}

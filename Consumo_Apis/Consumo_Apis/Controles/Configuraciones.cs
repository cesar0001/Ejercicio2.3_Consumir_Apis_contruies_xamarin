using System;
using System.Collections.Generic;
using System.Text;

namespace Consumo_Apis.Controles
{
   public class Configuraciones
    {
        public const string client_id = "VJMKF4LTPUGX5LYESDTNFJ51TGFYO5GPHDHCN3UBR0PGKRHE";
        public const string client_secret = "PRXJ0FEJY3HBHCQBCIMBX0EJWRACCOXSRWWKYYU1SKPBXYZV";
        public const string EndPointFoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";


    }

    public class sitios
    {
        public static String getUrl(double latitud,double longitud)
        {
           var url = String.Format(Configuraciones.EndPointFoursquare, latitud, longitud,
                Configuraciones.client_id, Configuraciones.client_secret, DateTime.Now.ToString("yyyyMMdd")  );

            return url;
        }

    }

}

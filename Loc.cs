using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alycia
{
    class Loc
    {
        public static string GetCityName(string ip)
        {
            string city;

            try
            {
                using (WebClient webC = new WebClient())
                {
                    string url = String.Format("http://ip-api.com/json/{0}", ip);

                    var json = webC.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<LocAPP.root>(json);

                    LocAPP.root saida = result;
                    city = saida.city;
                }
            }
            catch(Exception)
            {
                city = "error";
            }

            return city;
        }
    }
}

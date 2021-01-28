using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Alycia
{
    class ClimaTempo
    {

        private const string KEY = "API Token em apenwathermap.org ";


        public static List<string> GetInfoCity(string city)
        {
            List<string> infos = new List<String>();

            try
            {

                using (WebClient web = new WebClient())
                {
                    string url = String.Format("http://api.openweathermap.org/data/2.5/weather?q=Mineiros,Goias&appid=881be2d8893d21b3fa9245932265ab31&units=metric&lang=pt", city, KEY);

                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<ClimaTempoApp.root>(json);

                    ClimaTempoApp.root outPut = result;

                    infos.Add(outPut.nome); // [0] Nome da cidade
                    infos.Add(outPut.coord.lon.ToString()); // [1] Longitude
                    infos.Add(outPut.coord.lat.ToString()); // [2] Latitude
                    infos.Add(outPut.weather[0].main.ToString()); // [3] Situação (tipo, nublado)
                    infos.Add(outPut.weather[0].description.ToString()); // [4] Descrição (tipo, poucas nuvens)
                    infos.Add(outPut.main.temp.ToString()); // [5] Temperatura
                    infos.Add(outPut.main.temp_min.ToString()); // [6] Temperatura mínima
                    infos.Add(outPut.main.temp_max.ToString()); // [7] Temperatura máxima
                    infos.Add(outPut.main.feels_like.ToString()); // [8] Sensação térmica
                    infos.Add(Math.Round((outPut.main.pressure / 1003), 2).ToString()); // [9] Pressão do ar
                    infos.Add(outPut.main.humidity.ToString()); // [10] Humidade, porcentagem
                    infos.Add(outPut.wind.speed.ToString()); // [11] Velocidade do vento
                    infos.Add(outPut.wind.deg.ToString()); // [12] Direção em graus

                    return infos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ocorreu um erro ao buscar informações sobre o tempo" +
                    "\n Verifique sua conexão com a rede" +
                    "\n\n\n" + e.Message,"Erro ao buscar informações");

                infos.Clear();
                infos.Add("error");
            }

            return infos;
               
        }
    }
}

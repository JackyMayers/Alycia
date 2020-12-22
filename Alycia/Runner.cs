using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Net;

namespace Alycia
{
   
   public class Runner
    {
       private static string _retorno = "";
        //Fala nenhum mal
        public static void WhatTimeIS()
        {
            _retorno = DateTime.Now.ToShortTimeString();
            Speaker.Speak(_retorno);
        }
        public static void WhatDateIS()
        {
           _retorno = DateTime.Now.ToShortDateString();
           Speaker.Speak(_retorno);
        }
        public string resposta()
        {
            return _retorno;
        }
        public void setresposta(string r)
        {
            _retorno = r;
        }
        //Abrir Programas
        public static void AbrirVS()
        {
            Speaker.Speak("Entendido: Visual Studio");
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe");

        }
        public static void AbrirVSCode()
        {
            Speaker.Speak("Entendido: Visual Studio Code");
            System.Diagnostics.Process.Start(@"C:\Users\fluvi\AppData\Local\Programs\Microsoft VS Code\Code.exe");

        }
        public static void AbirNota()
        {
            Speaker.Speak("Entendido: bloco de notas");
            System.Diagnostics.Process.Start("notepad.exe");
        }
        public static void FecharNotas()
        {
            foreach (var process in Process.GetProcessesByName("notepad"))
            {
                process.CloseMainWindow();
                Speaker.Speak("Fechado");

            }


        }
        public static void OpenCalc()
        {
            Speaker.Speak("Entendido: Calculadora");
            System.Diagnostics.Process.Start("calc.exe");
        }
        public static void CloseCalc()
        {
            foreach (var process in Process.GetProcessesByName("calc"))
            {
                process.CloseMainWindow();
                Speaker.Speak("Fechado");

            }


        }
        //Internet
        public static void OpenEdge()
        {
            Speaker.Speak("Abrindo navegador Edge");
            System.Diagnostics.Process.Start("msedge.exe");

        }
        public static void OpenChrome()
        {
            Speaker.Speak("Abrindo navegador Chrome");
            System.Diagnostics.Process.Start("chrome.exe");

        }
        public static void PesquisaGoogle()
        {
            Speaker.Speak("Abrindo Google");
            System.Diagnostics.Process.Start("https://www.google.com");

        }
        public static void FecharEdge()
        {
            foreach (var process in Process.GetProcessesByName("msedge"))
            {
                process.CloseMainWindow();
            }


        }
        public static void FecharChrome()
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                process.CloseMainWindow();
            }


        }
        // Clima e tempo
        public static void GetTemperatura(string city)
        {
            List<string> infos = ClimaTempo.GetInfoCity(city);

            if (infos[0] == "error")
                return;

            Speaker.Speak("Hoje a temperatura é: " + infos[5] + "graus");
        }

        public static void GetMaininfos(string city)
        {
            List<string> infos = ClimaTempo.GetInfoCity(city);

            if (infos[0] == "error")
                return;

            string msg = String.Format(
                "Temperatura: {0} graus," +
                "Sensação térmica: {1} graus" +
                "Temperaturas previstas:  " +
                "Mínima de {2} graus," +
                "Máxima de {3} graus" +
                "Humidade do ar: {4}%",
                infos[5],
                infos[8],
                infos[6],
                infos[7],
                infos[10]                
                );
            Speaker.Speak(msg);

        }



        // Localização
        public static string GetIp()
        {
            return new WebClient().DownloadString("http://icanhazip.com/");
        }

        public static string GetLocation(string ip)
        {
            return Loc.GetCityName(ip);
        }


    }
}
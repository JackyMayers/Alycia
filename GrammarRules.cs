using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alycia
{
    public class GrammarRules
    // Hora e data
    {
        public static IList<string> WhatTimeIS = new List<string>()
        {
           "Alycia quantas horas",
           "Quantas horas",
           "Q T R Alycia"

        };
        public static IList<string> WhatDateIS = new List<string>()
        {
           "Alycia que dia é hoje"

        };
        public static IList<string> AlyciaStartListening = new List<string>()
        {
           "Q A P Alycia"
        };
        public static IList<string> AlyciaStopListening = new List<string>()
        {
           "T K S descançar",
           "Descansar Alycia"
        };
        // Comandos tamanho da janela
        public static IList<string> MinimizeWindow = new List<string>()
        {
           "Minimizar"
        };
        public static IList<string> MaximizaWindow = new List<string>()
        {
           "Maximizar"
        };
        public static IList<string> NormalizaWindow = new List<string>()
        {
           "Tamanho normal"
        };
        // Comando da voz
        public static IList<string> ChangeVoice = new List<string>()
        {
           "Alycia alterar voz"
        };
        // Abrir navegador e video do VS
        public static IList<string> OpenProgram = new List<string>()
        {
            "Alycia abre o navegador",
            "Alycia abre o video",
        };
        //Abrir explorador de arquivos
        public static IList<string> MediaPlayComands = new List<string>()
        {
            "Alycia abrir arquivo"
        };
        // Códigos Q, numericos e alfabeto
        public static IList<string> CodeQComands = new List<string>()
        {
            "Alycia código Q"
        };
        public static IList<string> TabNumComands = new List<string>()
        {
            "Alycia tabela de números"
        };
        public static IList<string> TabCodAlfInt = new List<string>()
        {
            "Alycia código do alfabeto"
        };
        // Comando das conversas troll
        public static IList<string> Cumpr = new List<string>() // Comando do cala a boca
        {
            "Oi Alycia"

        };
        public static IList<string> Obg = new List<string>() // Comando do delete
        {
            "Obrigado Alycia"
        };
        public static IList<string> TrollComand = new List<string>() //Comando do troll
        {
            "Alycia porque não está funcionando"
        };
        // Abir programas
        public static List<string> AbrirVSCode = new List<string>()
        {
            "Alycia abre o v s code",

        };
        public static List<string> AbrirVS = new List<string>()
        {
            "Alycia abre o visual studio",

        };
        public static List<string> AbrirNotas = new List<string>()
        {
            "Alycia abre bloco de notas"
        };
        public static List<string> FecharNotas = new List<string>()
        {
            "Alycia fecha bloco de notas"

        };
        //Internet
        public static List<string> PesquisaGoogle = new List<string>()
        {
            "Alycia abre google"

        };
        public static List<string> FecharEdge = new List<string>()
        {
            "Alycia feche o Edge"
        };
        public static List<string> OpenEdge = new List<string>()
        {
            "Alycia abre o Edge",
        };

        public static List<string> OpenCalc = new List<string>()
        {
            "Alycia abre a calculadora"
        };
        public static List<string> CloseCalc = new List<string>()
        {
            "Alycia fecha a calculadora"
        };
        public static List<string> OpenChrome = new List<string>()
        {
            "Alycia abre o Chrome",
        };
        public static List<string> FecharChrome = new List<string>()
        {
            "Alycia feche o Chrome",
        };

        // clima e tempo
        public static List<string> TempClim = new List<string>()
        {
            "Qual clima de hoje",
            "Alycia qual temperatura",
            "Alycia como ta o tempo"
        };
        public static List<string> MaisInfo = new List<string>()
        {
            "Alycia me de informações da cidade",
            "Alycia Informações da cidade",
            "Informações da cidade"
        };
        public static List<string> OpenSteam = new List<string>()
        {
            "Alycia abra a steam"
        };
        public static List<string> OpenDisc = new List<string>()
        {
            "Alycia abra o discord"
        };
        public static List<String> OpenEpic = new List<string>()
        {
            "Alycia abra a Epic"
        };
        public static List<String> OpenOBS = new List<string>()
        {
            "Alycia abra o OBS"
        };
        public static List<String> CloseAly = new List<string>()
        {
            "Alycia desligar"
        };
        public static List<String> OpenPokerstars = new List<string>()
        {
            "Alycia abre o Pokerstars"
        };

    }
    
    
}
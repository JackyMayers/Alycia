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
           "Para com isso",
           "Descansa Alycia"
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
           "Alterar voz"
        };
        // Abrir navegador e video do VS
        public static IList<string> OpenProgram = new List<string>()
        {
            "Navegador",
            "Video",
            
            
            
        };
        //Abrir explorador de arquivos
        public static IList<string> MediaPlayComands = new List<string>()
        {
            "Abrir arquivo"
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
        public static IList<string> CalaBoca = new List<string>() // Comando do cala a boca
        {
            "Alycia Cala a boca",
            "Cala a boca"
        };
        public static IList<string> VaiSerapagada = new List<string>() // Comando do delete
        {
            "Mas você vai junto"
        };
        public static IList<string> TrollComand = new List<string>() //Comando do troll
        {
            "Alycia eu sou bonito"
        };
        // Abir programas
        public static List<string> AbrirVSCode = new List<string>()
        {
            "Alycia abre o v s code",
            "Abrir V S Code"
        };
        public static List<string> AbrirVS = new List<string>()
        {
            "Alycia abre o visual studio",
            "Abrir Visual Studio"
        };
        public static List<string> AbrirNotas = new List<string>()
        {
            "Abrir bloco de notas",
            "Abrir bloco de nota",
            "Fazer anotações"
        };
        public static List<string> FecharNotas = new List<string>()
        {
            "Fechar bloco de notas",
            "Fechar anotações"
        };
        //Internet
        public static List<string> PesquisaGoogle = new List<string>()
        {
            "Abrir google",
            "Fazer pesquiza no google",
            "Google",
            "Visualizar google"
        };
        public static List<string> FecharGoogle = new List<string>()
        {
            "Fechar google",
            "Fechar crome",
            "Fechar internet"
        };
        public static List<string> OpenBrowser = new List<string>()
        {
            "Abrir internet",
            "Internet",
            "Alycia abre o Edge",
            "Quero acessar a internet"
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
    }
}
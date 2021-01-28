using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Speech.Recognition;//Houve
using System.Speech.Synthesis;


// Para sintese é presiso o speechSDK

namespace Alycia
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine engine; // Variavel de voz 
        private bool isAlyciaListering = true;
        private SelecVoz selectVoice = null;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer(); //Sintetizador
        private Browser browser;
        private Video mediaPlay;
        private string city;

        public Form1()
        {
            InitializeComponent();
        }
        #region
        private void speakStarted(object s, SpeakStartedEventArgs e)
        {
            LBLShmyt.Text = "Sistema: -";
        }
        private void speakProgress(object s, SpeakProgressEventArgs e)
        {
            LBLShmyt.Text += e.Text + " ";
        }
        
        
        private void Speak(String text)
        {
            synthesizer.SpeakAsync(text);

        }
        private void SpeakRand(params string[] texts)
        {
            Random r = new Random();
            Speak(texts[r.Next(0, texts.Length)]);


        } 

        #endregion
        private void Normalwindow()
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                Speak("Normalizando a janela");//, "Como quiser", "Tudo bem", "Vou fazer isto");
            }
            else
            {
                Speak("Já está Normalizada");//, "A janela já está Normalizada", "Já fiz isso");
            }
        }
        private void Maximawindow()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                Speak("Maximizando a janela");//, "Como quiser", "Tudo bem", "Vou fazer isto");
            }
            else
            {
                Speak("Já está maximizado");//, "A janela já está maximizada", "Já fiz isso");
            }
        }
        private void Minimizewindow()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                Speak("Minimizando a janela");//, "Como quiser", "Tudo bem", "Vou fazer isto");
            }
            else
            {
                Speak("Já está minimizada");//,"A janela já está minimizada", "Já fiz isso");
            }
        }
        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }
        public void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            this.label1.ForeColor = Color.Red;
        }
        // Metodo que é chamado quando algo é reconhecido
        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            Runner r = new Runner();
            //MessageBox.Show(e.Result.Text);
            string speech = e.Result.Text; // string reconecida
            float conf = e.Result.Confidence;
            // Criar log
            // ***********************************************                     
            this.label1.Text = ":>" + speech;
            if(conf > 0.35f)
            {
                
                this.label1.ForeColor = Color.Yellow;
                if(GrammarRules.AlyciaStopListening.Any(x => x == speech))
                {
                    r.setresposta("Mandou parar");
                    isAlyciaListering = false;
                    Speak("Q S L vou descansar, se precisar é só chamar");//, "Tá bem, desliguei", "Ok quando quiser é so chamar");
                }
                else if (GrammarRules.AlyciaStartListening.Any(x => x == speech))
                {
                    r.setresposta("Mandou continuar");
                    isAlyciaListering = true;
                    Speak("Q A P, Q R V");//, "Pronta pra te atender", "Tava dormindo, diga o que mandas");
                } else if (isAlyciaListering == true)
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "sys":
                            //Se o speech == comparação ("Que horas são?)
                            if (GrammarRules.Obg.Any(x => x == speech))
                            {
                                Speak("Tamo junto"); // Fala do delete
                            }
                            if (GrammarRules.Cumpr.Any(x => x == speech))
                            {
                                Speak("Oi, tudo bem?"); // Fala do cala a boca
                            }
                            if (GrammarRules.TrollComand.Any(x => x == speech)) 
                            {
                                Speak("Talvez seja porque você não saiba programar."); //Fala do Troll
                            }
                            if (GrammarRules.CodeQComands.Any(x => x == speech)) // Codigo Q
                            {
                                Speak("Ok, QAP Permaneça na escuta, fique atento, QRA Qual seu nome, ou qual o nome da sua estação, QRF Você esta regressando a …(lugar), QSA Intensidade dos sinais,QRM Estou sofrendo interferência,QRU Tem alguma coisa para mim, QRV Estou preparado, prossiga, QRX Espere, QSL Entendido, QTA Sem efeito, QTC Mensagem a transmitir, QTH Qual é a sua posição, endereço, lugar, QTI Qual o seu rumo verdadeiro, QTR Horas, QTX Mantenha sua estação aberta para comunicação, TKS Obrigado, RD Qual a sua localização, QRL Estou ocupado não interfira, QRR S.O.S. terrestre, QRT Parar de transmitir, QRU Você tem algo para mim, QRV Estarei a sua disposição, RZ Quem está chamando, QSJ Taxa, Dinheiro, QSL Confirmado – tudo entendido, QSM Repita o último câmbio, QSN Você me escutou, QTA Anule a mensagem anterior, QTB Concordo com a sua contagem de palavras, QTI Qual o seu destino, QTJ Qual a sua velocidade, QTU Horário de funcionamento da estação, QTX Sairei por tempo indeterminado, QTY A caminho do local do acidente, QUD Recebi seu sinal de urgência, QUF Recebi seu sinal de perigo.");
                            }
                            if (GrammarRules.TabNumComands.Any(x => x == speech)) // Codigo dos numeros
                            {
                                Speak("Tabela denumeros: 1 – Primo, 2 – Segundo, 3 – Terceiro, 4 – Quarto, 5 – Quinto, 6 – Sexto, 7 – Setimo, 8 – Oitavo, 9 – Nono, 0 – Negativo.");
                            }
                            if (GrammarRules.TabCodAlfInt.Any(x => x == speech)) // Codigo do alfabeto
                            {
                                Speak("A – Alfa, B – Bravo, C – Charlie, D – Delta, E – Eco, F – Fox-Trot, G – Golf, H – Hotel, I – India, J – Juliet, K – Kilo, L – Lima, M – Maike, N – Noverber, O – Oscar, P – Papa, Q – Quebec, R – Romeo, S – Sierra, T – Tango, U – Uniform, V – Victor, W – Whisk, Y – Yankey, Z – Zulu");
                            }
                            if (GrammarRules.WhatTimeIS.Any(x => x == speech))
                            {
                                Runner.WhatTimeIS(); // Hora
                            }
                            else if (GrammarRules.WhatDateIS.Any(x => x == speech))
                            {
                                Runner.WhatDateIS(); // Data
                            }
                            else if (GrammarRules.MinimizeWindow.Any(x => x == speech))
                            {
                                Minimizewindow(); // Minimaiza janela
                            }
                            else if (GrammarRules.MaximizaWindow.Any(x => x == speech))
                            {
                                Maximawindow(); //Maximiza Janela
                            }
                            else if (GrammarRules.NormalizaWindow.Any(x => x == speech))
                            {
                                Normalwindow(); // Tamnho normal
                            }
                            else if (GrammarRules.ChangeVoice.Any(x => x == speech))
                            {
                                //If(selectVoice == null)
                                selectVoice = new SelecVoz();
                                selectVoice.Show();
                            }
                            else if (GrammarRules.OpenEdge.Any(x => x == speech))
                            {
                                Runner.OpenEdge(); // Abre navegador Edge
                            }
                            else if (GrammarRules.OpenCalc.Any(x => x == speech))
                            {
                                Runner.OpenCalc(); // Abre a calculadora
                            }
                            else if (GrammarRules.CloseCalc.Any(x => x == speech))
                            {
                                Runner.CloseCalc(); // Fecha a calculadora
                            }
                            else if (GrammarRules.OpenChrome.Any(x => x == speech))
                            {
                                Runner.OpenChrome(); // Abre navegador Chrome
                            }
                            else if (GrammarRules.PesquisaGoogle.Any(x => x == speech))
                            {
                                Runner.PesquisaGoogle(); // Abre google navegador Edge
                            }
                            else if (GrammarRules.AbrirVSCode.Any(x => x == speech))
                            {
                                Runner.AbrirVSCode(); // Abre Visual Studio Code
                            }
                            else if (GrammarRules.AbrirVS.Any(x => x == speech))
                            {
                                Runner.AbrirVS(); // Abre Visual Studio
                            }
                            else if (GrammarRules.FecharEdge.Any(x => x == speech))
                            {
                                Speak("Fechando");
                                Runner.FecharEdge();
                            }
                            else if (GrammarRules.FecharChrome.Any(x => x == speech))
                            {
                                Speak("Fechando");
                                Runner.FecharChrome();
                            }
                            else if (GrammarRules.OpenSteam.Any(x => x == speech))
                            {
                                Runner.OpenSteam(); // Abre a Steam
                            }
                            else if (GrammarRules.OpenPokerstars.Any(x => x == speech))
                            {
                                Runner.OpenPokerstars(); // Abre o Pokerstars
                            }
                            else if (GrammarRules.OpenDisc.Any(x => x == speech))
                            {
                                Runner.OpenDisc(); // Abre o Discord
                            }
                            else if (GrammarRules.OpenEpic.Any(x => x == speech))
                            {
                                Runner.OpenEpic(); // Abre a Epic Games
                            }
                            else if (GrammarRules.OpenOBS.Any(x => x == speech))
                            {
                                Runner.OpenOBS(); // Abre o OBS
                            }
                            else if (GrammarRules.CloseAly.Any(x => x == speech))
                            {
                                this.Close();  // Fecha a assistente
                            }

                            else if (GrammarRules.AbrirNotas.Any(x => x == speech))
                            {
                                Runner.AbirNota();
                            }
                            else if (GrammarRules.FecharNotas.Any(x => x == speech))
                            {
                                Runner.FecharNotas();
                            }
                            else if (GrammarRules.TempClim.Any(x => x == speech))
                            {
                                Runner.GetTemperatura(city);
                            }
                            else if (GrammarRules.MaisInfo.Any(x => x == speech))
                            {
                                Runner.GetMaininfos(city);
                            }
                            else if (GrammarRules.OpenProgram.Any(x => x == speech))
                            {
                                switch (speech)
                                {
                                    case "Alycia abre o navegador":
                                        browser = new Browser();
                                        browser.Show();
                                        break;
                                    case "Alycia abre o video":
                                        mediaPlay = new Video();
                                        mediaPlay.Show();
                                        break;
                                }
                            }
                            else if (GrammarRules.MediaPlayComands.Any(x => x == speech))
                            {
                                switch (speech)
                                {
                                    case "Alycia abrir arquivo":
                                        if (mediaPlay != null)
                                        {
                                            Speak("Selecione um arquivo");
                                            mediaPlay.OpenFile();
                                        }
                                        else
                                        {
                                            Speak("Media player não está aberto");
                                        }
                                        break;
                                }
                            }
                            break;

                        case "calc":
                            Speak(CalcSolver.solver(speech));
                            break;
                    }
                }
               
            }

            //********************************************************************************************************************
            string date = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            string log_filename = "log\\" + date + ".txt";

            StreamWriter sw = File.AppendText(log_filename);

            if (File.Exists(log_filename))
            {
                sw.WriteLine(speech + "=" + r.resposta());
            }
            else
            {
                sw.WriteLine(speech + "=" + r.resposta());

            }
            sw.Close();

            // else
            //{
            // this.label1.ForeColor = Color.White;
            //}
            // this.label1.ForeColor = Color.White;
        }

        private void LoadSpeech()
        {
            try
            {
               
                engine = new SpeechRecognitionEngine();// Instancia
                engine.SetInputToDefaultAudioDevice();// Microfone
                // string[] words = { "Olá", "Boa noite" };
                                                      // Operações
                Choices c_numero = new Choices();
                for (int i=0; i <= 1000; i++)
                {
                    c_numero.Add(i.ToString());
                }


                // Hora e data
                Choices c_commandsOfSystem = new Choices();
                c_commandsOfSystem.Add(GrammarRules.WhatTimeIS.ToArray());
                c_commandsOfSystem.Add(GrammarRules.WhatDateIS.ToArray());
                // Comando pare de ouvir e o comando pra voltar a ouvir ->> Alycia
                c_commandsOfSystem.Add(GrammarRules.AlyciaStopListening.ToArray());
                c_commandsOfSystem.Add(GrammarRules.AlyciaStartListening.ToArray());
                // Comandos tamanho da janela
                c_commandsOfSystem.Add(GrammarRules.MinimizeWindow.ToArray());
                c_commandsOfSystem.Add(GrammarRules.MaximizaWindow.ToArray());
                c_commandsOfSystem.Add(GrammarRules.NormalizaWindow.ToArray());
                // Comando trocar voz
                c_commandsOfSystem.Add(GrammarRules.ChangeVoice.ToArray());
                // nvegador e video do VS
                c_commandsOfSystem.Add(GrammarRules.OpenProgram.ToArray());
                c_commandsOfSystem.Add(GrammarRules.MediaPlayComands.ToArray());
                //Comando de fala Troll, QAP Primeiro Alfa
                c_commandsOfSystem.Add(GrammarRules.CodeQComands.ToArray());
                c_commandsOfSystem.Add(GrammarRules.TabNumComands.ToArray());
                c_commandsOfSystem.Add(GrammarRules.TabCodAlfInt.ToArray());
                c_commandsOfSystem.Add(GrammarRules.TrollComand.ToArray());
                c_commandsOfSystem.Add(GrammarRules.Cumpr.ToArray());
                c_commandsOfSystem.Add(GrammarRules.Obg.ToArray());
                //Comandos abrir programas
                c_commandsOfSystem.Add(GrammarRules.OpenEdge.ToArray());//Abir browser
                c_commandsOfSystem.Add(GrammarRules.AbrirNotas.ToArray());//Abrir Notas
                c_commandsOfSystem.Add(GrammarRules.PesquisaGoogle.ToArray());
                c_commandsOfSystem.Add(GrammarRules.FecharEdge.ToArray());
                c_commandsOfSystem.Add(GrammarRules.FecharNotas.ToArray());
                c_commandsOfSystem.Add(GrammarRules.AbrirVS.ToArray());
                c_commandsOfSystem.Add(GrammarRules.AbrirVSCode.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenChrome.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenCalc.ToArray());
                c_commandsOfSystem.Add(GrammarRules.CloseCalc.ToArray());
                c_commandsOfSystem.Add(GrammarRules.FecharChrome.ToArray());
                c_commandsOfSystem.Add(GrammarRules.TempClim.ToArray());
                c_commandsOfSystem.Add(GrammarRules.MaisInfo.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenSteam.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenDisc.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenEpic.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenOBS.ToArray());
                c_commandsOfSystem.Add(GrammarRules.CloseAly.ToArray());
                c_commandsOfSystem.Add(GrammarRules.OpenPokerstars.ToArray());


                GrammarBuilder gb_comandOfSystem = new GrammarBuilder();// 4:22
                gb_comandOfSystem.Append(c_commandsOfSystem);

                Grammar g_comandsOfSystem = new Grammar(gb_comandOfSystem);
                g_comandsOfSystem.Name = "sys";

                engine.LoadGrammar(g_comandsOfSystem);//Carrega gramatica na memoria

                // Gramabuilder numeros
                GrammarBuilder gb_number = new GrammarBuilder();
                gb_number.Append(c_numero);
                gb_number.Append(new Choices("mais", "menos", "vezes", "por"));
                gb_number.Append(c_numero);

                Grammar g_numero = new Grammar(gb_number);
                g_numero.Name = "calc";
                engine.LoadGrammar(g_numero);
                // Carregar gramatica substituido por choise 
                // engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));
                // Chamar o evento do reconhecimento comentado pelo video 03

                #region SpeechRecognition Events 
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                //Barra de progresso
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);
                //engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);
                #endregion 

                #region SpeechRecognition Events 
                synthesizer.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(speakStarted);
                synthesizer.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(speakProgress);
                #endregion 

                // Inicia o reconhecimento
                engine.RecognizeAsync(RecognizeMode.Multiple);

                Speaker.Speak("Carregando as configurações");
                city = Loc.GetCityName(Runner.GetIp()).ToLower();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro no LoadSpeech() " + ex.Message);
            }

        }

        private void Synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadSpeech();
            Speaker.Speak("Configurações carregadas, estou pronta");
        }

    }
}



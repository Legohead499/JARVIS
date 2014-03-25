using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;
using iTunesLib;

namespace JARVIS
{
    public partial class Jarvis : Form
    {
        public static WelcomeAndGoodbye wAndG;
        public static Email email;
        public static Speak speak = new Speak();
        public static Calender calender;
        public static Weather weather;
        public static string choice;
        public static iTunesApp app;
        public static int volume = 50;
        public static SpeechRecognitionEngine myVoice = new SpeechRecognitionEngine();
        System.Windows.Forms.Timer stopListeningTimer = new System.Windows.Forms.Timer();

        public Jarvis()
        {
            InitializeComponent();
            myVoice.SetInputToDefaultAudioDevice();
            string[] phrases = getPhrases();
            myVoice.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(phrases))));
            myVoice.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(myVoice_SpeechRecognized);
            myVoice.RecognizeAsync(RecognizeMode.Multiple);
            loadUpWelcome();
            stopListeningTimer.Tick += new EventHandler(time_Tick);
            stopListeningTimer.Interval = 1000;
        }

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);
        private void myVoice_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {            
            string input = e.Result.Text;
            switch (input.ToUpper())
            {

                case ("HOW IS THE WEATHER"):
                case ("WEATHER"):
                case ("HOWS THE WEATHER"):
                case ("HOW'S THE WEATHER"):
                    getWeather();
                    break;


                case ("TOMORROWS FORECAST"):
                case ("TOMORROWS WEATHER"):
                case ("HOWS TOMORROWS WEATHER"):
                case ("HOW IS TOMORROWS WEATHER"):
                case ("WHATS TOMORROW LIKE"):
                case ("WHATS IT LIKE TOMORROW"):
                case ("FORECAST"):
                    getForecast();
                    break;

                case ("MAIL"):
                case ("EMAIL"):
                case ("EMAILS"):
                case ("OPEN MAIL"):
                case ("OPEN EMAIL"):
                case ("OUTLOOK"):
                case ("READ MAIL"):
                case ("READ EMAIL"):
                case ("READ EMAILS"):
                case ("SHOW MAIL"):
                case ("SHOW EMAIL"):
                case ("SHOW EMAILS"):
                    readMail();
                    break;

                case ("SEND MAIL"):
                case ("SEND EMAIL"):
                case ("SEND EMAILS"):
                case ("SEND AN EMAIL"):
                case ("SEND MESSAGE"):
                    sendMail();
                    break;

                case ("SEARCH"):
                case ("SEARCH FOR"):
                case ("FIND"):
                    search("");
                    break;

                case ("CALENDER"):
                case ("CHECK CALENDER"):
                case ("APPOINTMENTS"):
                case ("TASKS"):
                    checkCalender();
                    break;

                case ("REVISION"):
                    calender = new Calender();
                    calender.revisionPapers("Revision");
                    break;

                case ("GOOGLE"):
                    googleSearch("");
                    break;

                case ("SHOW TIME"):
                case ("TIME"):
                case ("CURRENT TIME"):
                case ("TELL TIME"):
                case ("SAY TIME"):
                    currentTime();
                    break;

                case ("SHOW DAY"):
                case ("DAY"):
                case ("CURRENT DAY"):
                case ("TELL DAY"):
                case ("SAY DAY"):
                case ("SHOW DATE"):
                case ("DATE"):
                case ("CURRENT DATE"):
                case ("TELL DATE"):
                case ("SAY DATE"):
                    currentDate();
                    break;

                case ("HELLO"):
                case ("HEY JARVIS"):
                case ("HEY"):
                case ("SUP"):
                case ("GOOD MORNING"):
                case ("GOOD AFTERNOON"):
                case ("GOOD EVENING"):
                    helloResponse();
                    break;

                case ("SHUTDOWN"):
                case ("TURN OFF"):
                    choice = "SHUTDOWN";
                    operation(choice);
                    break;

                case ("SHUTDOWN EFFECTIVE IMMEDIATELY"):
                case ("SHUTDOWN NOW"):
                    choice = "SHUTDOWN NOW";
                    operation(choice);
                    break;

                case ("RESTART"):
                    choice = "RESTART";
                    operation(choice);
                    break;

                case ("RESTART EFFECTIVE IMMEDIATELY"):
                case ("RESTART NOW"):
                    choice = "RESTART NOW";
                    operation(choice);
                    break;

                case ("LOGOFF"):
                case ("LOG OFF"):
                    choice = "LOGOFF";
                    operation(choice);
                    break;

                case ("LOGOFF EFFECTIVE IMMEDIATELY"):
                case ("LOG OFF EFFECTIVE IMMEDIATELY"):
                case ("LOGOFF NOW"):
                    choice = "LOGOFF NOW";
                    operation(choice);
                    break;

                case ("LOCK"):
                case ("LOCK COMPUTER"):
                case ("LOCK MACHINE"):
                case ("LOCK LAPTOP"):
                    choice = "LOCK";
                    operation(choice);
                    break;

                case ("LOCK EFFECTIVE IMMEDIATELY"):
                case ("LOCK COMPUTER EFFECTIVE IMMEDIATELY"):
                case ("LOCK MACHINE EFFECTIVE IMMEDIATELY"):
                case ("LOCK LAPTOP EFFECTIVE IMMEDIATELY"):
                case ("LOCK NOW"):
                    choice = "LOCK NOW";
                    operation(choice);
                    break;


                case ("ITUNES CONTROL"):
                case ("ITUNES CONTROLLER"):
                    Thread load = new Thread(new ThreadStart(() => speak.loading()));
                    load.IsBackground = true;
                    load.Start();
                    Process.Start(@"C:\Users\Alex\Documents\visual studio 2012\Projects\ITunesSongPlayer\ITunesSongPlayer\obj\Debug\ITunesSongPlayer.exe");
                    break;

                case ("PLAY"):
                case ("PLAY ITUNES"):
                case ("PLAY SONG"):
                    app = new iTunesApp();
                    app.Play();
                    break;

                case ("PAUSE"):
                case ("PAUSE ITUNES"):
                case ("PAUSE SONG"):
                    app = new iTunesApp();
                    app.Pause();
                    break;

                case ("NEXT"):
                case ("NEXT SONG"):
                    app = new iTunesApp();
                    app.NextTrack();
                    app.Play();
                    break;

                case ("PREVIOUS"):
                case ("PREVIOUS SONG"):
                case ("LAST SONG"):
                    app = new iTunesApp();
                    app.PreviousTrack();
                    app.Play();
                    break;

                case ("SHUFFLE"):
                case ("SHUFFLE ITUNES"):
                    app = new iTunesApp();
                    app.CurrentPlaylist.Shuffle = true;
                    app.Play();
                    break;

                case ("TURN DOWN VOLUME"):
                case ("TURN DOWN ITUNES"):
                case ("TURN DOWN SONG VOLUME"):
                case ("TURN DOWN THE VOLUME"):
                case ("TURN DOWN THE SONG VOLUME"):
                case ("TURN DOWN"):
                case ("VOLUME DOWN"):
                    turnDownItunes();
                    break;

                case ("TURN UP VOLUME"):
                case ("TURN UP ITUNES"):
                case ("TURN UP SONG VOLUME"):
                case ("TURN UP THE VOLUME"):
                case ("TURN UP THE SONG VOLUME"):
                case ("TURN UP"):
                case ("VOLUME UP"):
                    turnUpItunes();
                    break;

                case ("RUNESCAPE"):
                case ("RS"):
                    loadProgram(@"C:\Users\Alex\Desktop\Runescape");
                    break;

                case ("LEAGUE OF LEGENDS"):
                case ("LOL"):
                case ("LEAGUE"):
                    loadProgram(@"C:\Riot Games\League of Legends\lol.launcher.exe");
                    break;

                case ("LOLESPORTS"):
                case ("LOL ESPORTS"):
                case ("WATCH LEAGUE"):
                    Process.Start("http://euw.lolesports.com/");

                    Thread loadLeague = new Thread(new ThreadStart(() => speak.loading()));
                    loadLeague.IsBackground = true;
                    loadLeague.Start();
                    break;

                case ("ASSASSINS CREED 4"):
                case ("ASSASSINS CREED IV"):
                case ("ASSASSINS CREED"):
                case ("AC4"):
                    loadProgram(@"C:\Program Files (x86)\Assassins Creed IV Black Flag\AC4BFSP.exe");
                    break;

                case ("JARVIS QUIET"):
                case ("JARVIS SH"):
                case ("JARVIS VOLUME DOWN"):
                    jarvisVolume(true);
                    break;

                case ("JARVIS LOUD"):
                case ("I CANT HEAR YOU"):
                case ("I CANT HEAR YOU JARVIS"):
                case ("JARVIS VOLUME UP"):
                    jarvisVolume(false);
                    break;

                case ("JARVIS MUTE"):
                case ("MUTE"):
                    jarvisMute(true);
                    break;

                case ("JARVIS SPEAK"):
                case ("UNDO MUTE"):
                    jarvisMute(false);
                    break;

                case ("TO DO"):
                case ("TODO"):
                    speak.readOrWrite();
                    toDo();
                    break;

                case ("COMMANDS"):
                case ("COMMAND"):
                case ("WHAT CAN I DO"):
                case ("WHAT CAN I SAY"):
                    commands();
                    break;

                case ("SWITCH WINDOWS"):
                case ("SWITCH WINDOW"):
                    Process[] procs = Process.GetProcessesByName("JARVIS.vshost");
                    foreach (Process proc in procs)
                    {
                        //switch to process by name
                        SwitchToThisWindow(proc.MainWindowHandle, false);
                    }
                    Console.WriteLine("Switch");
                    break;

                case ("STOP LISTENING"):
                    stopListening();
                    break;

                case ("QUIT"):
                case ("Q"):
                case ("STOP"):
                case ("END"):
                case ("CLOSE"):
                    endProgram(this);
                    break;

                default:
                    loadProgram(input);
                    break;
            }            
        }

        

        //..........................................Welcome/Goodbye/Hello Response messages................................

        public static void loadUpWelcome()
        {
            wAndG = new WelcomeAndGoodbye();
            Thread welcomeThread = new Thread(new ThreadStart(wAndG.welcome));
            welcomeThread.IsBackground = true;
            welcomeThread.Start();
        }


        public static void endProgram(Form thisForm)
        {
            wAndG = new WelcomeAndGoodbye();
            Thread goodbyeThread = new Thread(new ThreadStart(wAndG.goodbye));
            goodbyeThread.IsBackground = true;
            goodbyeThread.Start();
            goodbyeThread.Join();
            thisForm.Close();
        }

        public static void helloResponse()
        {

            Thread hello = new Thread(new ThreadStart(speak.hello));
            hello.IsBackground = true;
            hello.Start();
        }

        public static void clearAll()
        {
            Console.Clear();
        }

        //....................................................................................................

        //........................................Weather.....................................................
        public static void getWeather()
        {
            weather = new Weather();
            string[] foundConditions = weather.getWeather();
            ThreadStart weatherThreadStart = new ThreadStart(() => sayConditions(foundConditions));
            Thread weatherThread = new Thread(weatherThreadStart);
            weatherThread.IsBackground = true;
            weatherThread.Start();
        }

        public static void sayConditions(string[] foundConditions)
        {

            PromptBuilder builder = new PromptBuilder();
            builder.StartVoice("IVONA 2 Brian");
            builder.AppendText("The weather in hale sowen is " + foundConditions[0] + " at " + foundConditions[1] + " degrees. There is a wind speed of " + foundConditions[2] + " miles per hour with highs of " + foundConditions[3] + " and lows of " + foundConditions[4]);
            builder.EndVoice();
            using (SpeechSynthesizer sayWeather = new SpeechSynthesizer())
            {
                sayWeather.Speak(builder);
            }
        }

        public static void getForecast()
        {

            weather = new Weather();
            string[] foundConditions = weather.getWeather();
            Thread forecast = new Thread(new ThreadStart(() => speak.sayForecast(foundConditions)));
            forecast.IsBackground = true;
            forecast.Start();
        }

        //.....................................................................................................

        //......................................Email..........................................................
        public static void readMail()
        {
            email = new Email();
            email.openMail();
        }

        public static void sendMail()
        {
            email = new Email();
            email.sendMail();
        }
        //.....................................................................................................

        //.....................................Load if .exe....................................................
        public void loadProgram(string input)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(input);
                Process pro = new Process();
                pro.StartInfo = psi;
                if (pro.Start())
                {
                    Thread load = new Thread(new ThreadStart(() => speak.loading()));
                    load.IsBackground = true;
                    load.Start();
                }
            }
            catch
            {

                Thread noOptAvail = new Thread(new ThreadStart(() => speak.noOptionAvailable()));
                noOptAvail.IsBackground = true;
                noOptAvail.Start();

            }
        }
        //.....................................................................................................

        //.....................................Search Files....................................................

        public static Search getSearchFile = new Search();
        public void search(string getFile)
        {
            getFileName();
        }

        public static SpeechRecognitionEngine whatToSearch = new SpeechRecognitionEngine();
        public string getFile = "No Data";
        public void getFileName()
        {
            getSearchFile.Show();
            myVoice.RecognizeAsyncCancel();
            whatToSearch.SetInputToDefaultAudioDevice();
            whatToSearch.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(getPhrases()))));
            whatToSearch.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(whatToSearch_SpeechRecognized);
            whatToSearch.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void whatToSearch_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToUpper().Equals("SEARCH"))
            {
                Console.WriteLine("HERE 1");
               this.getFileMethod = getSearchFile.inputFound();
               Console.WriteLine("Searching");
               try
               {
                   myVoice.RecognizeAsync(RecognizeMode.Multiple);
               }
               catch
               {
               }
               whatToSearch.RecognizeAsyncStop();
               findFile(getFile);
            }
        }

        public string getFileMethod
        {
            get
            {
                return getFile;
            }
            set
            { getFile = value;
            }
        }



        public static void findFile(string filename)
        {
            getSearchFile.Close();
            string[] files = null;

            try
            {
                files = Directory.GetFiles("C:\\Users\\Alex\\Downloads", filename + ".*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.ToString());
            }

            if (files != null)
            {
                foreach (string file in files)
                {
                    Console.WriteLine(file);

                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo(file);
                        Process proc = new Process();
                        proc.StartInfo = psi;
                        if (proc.Start())
                        {
                            Thread loading = new Thread(new ThreadStart(() => speak.loading()));
                            loading.IsBackground = true;
                            loading.Start();
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        //.....................................................................................................

        //.....................................Check Calender..................................................
        public static void checkCalender()
        {
            calender = new Calender();
            calender.calenderAppointments();
        }
        //.....................................................................................................

        //........................................Google search................................................

        public static SpeechRecognitionEngine whatToGoogle = new SpeechRecognitionEngine();
        public static void googleSearch(string input)
        {

            string searchTemplate = "www.google.com/search?q=";
            if (input.Equals(""))
            {
                string[] phrases = getPhrases();
                Thread searchForThread = new Thread(new ThreadStart(() => speak.searchFor()));
                searchForThread.IsBackground = true;
                searchForThread.Start();
                myVoice.RecognizeAsyncCancel();
                whatToGoogle.SetInputToDefaultAudioDevice();
                whatToGoogle.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(phrases))));
                whatToGoogle.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(whatToGoogle_SpeechRecognized);
                whatToGoogle.RecognizeAsync(RecognizeMode.Multiple);

            }
            else
            {
                Process.Start(searchTemplate + input);

                Thread loading = new Thread(new ThreadStart(() => speak.loading()));
                loading.IsBackground = true;
                loading.Start();
            }
        }

        private static void whatToGoogle_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!e.Result.Text.ToUpper().Equals("OTHER"))
            {
                string searchTemplate = "www.google.com/search?q=";
                string input = e.Result.Text;
                Process.Start(searchTemplate + input);
            }
            else
            {
                googleOther other = new googleOther();
                other.Show();
            }

            Thread loading = new Thread(new ThreadStart(() => speak.loading()));
            loading.IsBackground = true;
            loading.Start();
            try
            {
                myVoice.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
            }
            whatToGoogle.RecognizeAsyncStop();

        }
        //...................................................................................................

        //........................................Get Time and Date..........................................
        public static void currentTime()
        {

            speak.currentTime();
        }

        public static void currentDate()
        {

            speak.currentDate();
        }
        //..................................................................................................

        //...........................................Shutdown/Restart.......................................
        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        public static void operation(string choice)
        {

            if (choice.Contains(' '))
            {
                choice = choice.Substring(0, choice.IndexOf(' ')).ToLower();
            }
            switch (choice.ToUpper())
            {
                case ("SHUTDOWN"):
                    using (SpeechSynthesizer option = new SpeechSynthesizer())
                    {
                        option.Speak("Shutting down computer.");
                    }
                    Process.Start("shutdown", "-s");
                    break;
                case ("RESTART"):
                    using (SpeechSynthesizer option = new SpeechSynthesizer())
                    {
                        option.Speak("Restarting computer.");
                    }
                    Process.Start("shutdown", "-r");
                    break;
                case ("LOGOFF"):
                    using (SpeechSynthesizer option = new SpeechSynthesizer())
                    {
                        option.Speak("Logging off computer.");
                    }
                    Process.Start("shutdown", "-l");
                    break;
                case ("LOCK"):
                    using (SpeechSynthesizer option = new SpeechSynthesizer())
                    {
                        option.Speak("Locking computer.");
                    }
                    LockWorkStation();
                    break;

            }
        }
        //..................................................................................................

        //....................................................TBC.........................................

        public static void turnUpItunes()
        {
            app = new iTunesApp();
            volume += 20;
            app.SoundVolume = volume;
        }

        public static void turnDownItunes()
        {
            app = new iTunesApp();
            volume -= 20;
            app.SoundVolume = volume;
        }

        //..................................................................................................

        //....................................................TBC.........................................


        //..................................................................................................

        //....................................................Other.........................................


        public static SpeechRecognitionEngine readOrWrite = new SpeechRecognitionEngine();
        public static void toDo()
        {
            myVoice.RecognizeAsyncStop();
            readOrWrite.SetInputToDefaultAudioDevice();
            readOrWrite.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(getPhrases()))));
            readOrWrite.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(readOrWrite_SpeechRecognized);
            readOrWrite.RecognizeAsync(RecognizeMode.Multiple);
            
        }

        public static SpeechRecognitionEngine whatToWrite = new SpeechRecognitionEngine();
        public static writeToDo wTD = new writeToDo();
        private static void readOrWrite_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToUpper().Equals("READ"))
            {
                string[] toDoList = File.ReadAllLines(@"C:\Users\Alex\Desktop\JARVIS\ToDo.txt");
                speak.sayToDo(toDoList);                
            }
            else if (e.Result.Text.ToUpper().Equals("WRITE") || e.Result.Text.ToUpper().Equals("RIGHT"))
            {
                speak.write();
                wTD.Show();
            }
            else
            {
                speak.noOptionAvailable();
            }
            try
            {
                myVoice.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
            }
            readOrWrite.RecognizeAsyncStop();
        }

        public static void commands()
        {
            string[] availableCommands = File.ReadAllLines(@"C:\Users\Alex\Desktop\JARVIS\Commands.txt");

            bool newPara = false;
            foreach (string command in availableCommands)
            {
                if (newPara)
                {
                    using (SpeechSynthesizer sayCommand = new SpeechSynthesizer())
                    {
                        sayCommand.Speak(command);
                    }
                }
                if (!command.Equals(""))
                {
                    Console.WriteLine(command);
                    newPara = false;
                }
                else
                {
                    Console.WriteLine();
                    newPara = true;
                }
            }
        }

        public static void jarvisVolume(bool volumeDown)
        {

            speak.jarvisVol(volumeDown);
        }

        public static void jarvisMute(bool mute)
        {

            speak.jarvisMute(mute);
        }

        public static string[] getPhrases()
        {
            string[] phrases = File.ReadAllLines(@"C:\Users\Alex\Desktop\JARVIS\Grammar.txt");
            int index = 0;
            foreach (string phrase in phrases)
            {
                if (phrase == string.Empty)
                {
                    phrases[index] = "Empty";
                }
                index++;
            }
            return phrases;
        }

        int time = 10;
        public void stopListening()
        {
            time = 10;
            myVoice.RecognizeAsyncStop();
            Console.WriteLine("Not Listening");
            stopListeningTimer.Start();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            time = time - 1;
            Console.WriteLine(time.ToString());
            if (time == 0)
            {
                myVoice.RecognizeAsync(RecognizeMode.Multiple);
                Console.WriteLine("You may speak");
                stopListeningTimer.Stop();
            }
        }
        //..................................................................................................


        private void Jarvis_Load(object sender, EventArgs e)
        {

        }

        private void Jarvis_Click(object sender, EventArgs e)
        {
            time = 1;
        }

    }
}

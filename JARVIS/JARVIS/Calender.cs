using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Reflection;
using System.Threading;

namespace JARVIS
{
    public class Calender
    {
        Speak generic;
        ExamPapers exampapers;
        Application outLookApp = new Application();
        public void calenderAppointments()
        {
            generic = new Speak();
            try
            {
                DateTime start = DateTime.Now;
                DateTime end = start.AddDays(5);
                int index = 1;

                NameSpace outlookNameSpace = outLookApp.GetNamespace("MAPI");
                MAPIFolder calender = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                Items calenderItems = getAppointmentsInRange(calender, start, end);
                if (calenderItems != null)
                {
                    //set bool here change in foreach ask after foreach for change
                    foreach (AppointmentItem appointment in calenderItems)
                    {
                        string[] appointmentContent = { index.ToString(), appointment.Subject, appointment.Start.Date.ToString("d"), appointment.Start.TimeOfDay.ToString(), appointment.Location };
                        Thread sayAppointment = new Thread(new ThreadStart(() => generic.sayAppointment(appointmentContent)));
                        sayAppointment.IsBackground = true;
                        sayAppointment.Start();
                        Thread.Sleep(8000);
                        index++;
                        if (appointment.Subject.ToUpper().Contains("REVISION"))
                        {
                            revisionPapers(appointment.Subject);
                        }
                    }
                }
                else
                {
                    Thread noAppointment = new Thread(new ThreadStart(() => generic.sayAppointmentError()));
                    noAppointment.IsBackground = true;
                    noAppointment.Start();

                }
            }
            catch
            {
                Thread noAppointment = new Thread(new ThreadStart(() => generic.sayAppointmentError()));
                noAppointment.IsBackground = true;
                noAppointment.Start();

            }

        }

        public Items getAppointmentsInRange(MAPIFolder folder, DateTime start, DateTime end)
        {
            string filter = "[Start] >= '" + start.ToString("g") + "' AND [End] <= '" + end.ToString("g") + "'";

            try
            {
                Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Items restictItems = calItems.Restrict(filter);
                if (restictItems.Count > 0)
                {
                    return restictItems;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public void revisionPapers(string revision)
        {
            generic = new Speak();
            try
            {
                revision = revision.Substring(0, revision.IndexOf(' '));
            }
            catch
            {
                revision = "Ask Subject";
            }
            switch (revision.ToUpper())
            {
                case ("ACCOUNTS"):
                case ("ACCOUNTING"):
                case ("ACC"):
                case ("ACCN"):
                    accounts();
                    break;

                case ("COMPUTING"):
                case ("COMP"):
                    computing();
                    break;

                case ("MATHS"):
                case ("MATH"):
                    maths();
                    break;

                default:
                    Thread whatSubject = new Thread(new ThreadStart(() => generic.whatSubject()));
                    whatSubject.IsBackground = true;
                    whatSubject.Start();
                    string input = Console.ReadLine();
                    input = input + " revision";
                    revisionPapers(input);
                    break;

            }
        }

        public void accounts()
        {
            generic = new Speak();
            exampapers = new ExamPapers();
            Thread accountsThread = new Thread(new ThreadStart(() => generic.getPapers("accounts")));
            accountsThread.IsBackground = true;
            accountsThread.Start();
            string input = "";
            bool exitSwitch = false;

            do
            {
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case ("YES"):
                    case ("Y"):
                    case ("OK"):
                    case ("PLEASE"):
                    case ("ACCEPT"):
                        exampapers.getPapers("Accounting");
                        exitSwitch = true;
                        break;

                    case ("NO"):
                    case ("N"):
                    case ("NO THANKS"):
                    case ("NO THANK YOU"):
                    case ("DECLINE"):
                        Thread noPapers = new Thread(new ThreadStart(() => generic.noPapers()));
                        exitSwitch = true;
                        break;

                    case ("QUIT"):
                    case ("EXIT"):
                    case ("Q"):
                    case ("STOP"):
                    case ("END"):
                        break;

                    default:
                        Thread noCommand = new Thread(new ThreadStart(() => generic.noOptionAvailable()));
                        break;
                }
            } while (!input.ToUpper().Equals("QUIT") && !input.ToUpper().Equals("EXIT") && !input.ToUpper().Equals("Q") && !input.ToUpper().Equals("STOP") && !input.ToUpper().Equals("END") &&
                        exitSwitch == false);

        }

        public void computing()
        {
            generic = new Speak();
            exampapers = new ExamPapers();
            Thread computingThread = new Thread(new ThreadStart(() => generic.getPapers("computing")));
            computingThread.IsBackground = true;
            computingThread.Start();
            string input = "";
            bool exitSwitch = false;

            do
            {
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case ("YES"):
                    case ("Y"):
                    case ("OK"):
                    case ("PLEASE"):
                    case ("ACCEPT"):
                        exampapers.getPapers("Computing");
                        exitSwitch = true;
                        break;

                    case ("NO"):
                    case ("N"):
                    case ("NO THANKS"):
                    case ("NO THANK YOU"):
                    case ("DECLINE"):
                        Thread noPapers = new Thread(new ThreadStart(() => generic.noPapers()));
                        exitSwitch = true;
                        break;

                    case ("QUIT"):
                    case ("EXIT"):
                    case ("Q"):
                    case ("STOP"):
                    case ("END"):
                        break;

                    default:
                        Thread noCommand = new Thread(new ThreadStart(() => generic.noOptionAvailable()));
                        break;
                }
            } while (!input.ToUpper().Equals("QUIT") && !input.ToUpper().Equals("EXIT") && !input.ToUpper().Equals("Q") && !input.ToUpper().Equals("STOP") && !input.ToUpper().Equals("END") &&
                        exitSwitch == false);
        }

        public void maths()
        {
            generic = new Speak();
            exampapers = new ExamPapers();
            Thread mathsThread = new Thread(new ThreadStart(() => generic.getPapers("maths")));
            mathsThread.IsBackground = true;
            mathsThread.Start();
            string input = "";
            bool exitSwitch = false;

            do
            {
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case ("YES"):
                    case ("Y"):
                    case ("OK"):
                    case ("PLEASE"):
                    case ("ACCEPT"):
                        exampapers.getPapers("Maths");
                        exitSwitch = true;
                        break;

                    case ("NO"):
                    case ("N"):
                    case ("NO THANKS"):
                    case ("NO THANK YOU"):
                    case ("DECLINE"):
                        Thread noPapers = new Thread(new ThreadStart(() => generic.noPapers()));
                        exitSwitch = true;
                        break;

                    case ("QUIT"):
                    case ("EXIT"):
                    case ("Q"):
                    case ("STOP"):
                    case ("END"):
                        break;

                    default:
                        Thread noCommand = new Thread(new ThreadStart(() => generic.noOptionAvailable()));
                        break;
                }
            } while (!input.ToUpper().Equals("QUIT") && !input.ToUpper().Equals("EXIT") && !input.ToUpper().Equals("Q") && !input.ToUpper().Equals("STOP") && !input.ToUpper().Equals("END") &&
                        exitSwitch == false);
        }


    }
}

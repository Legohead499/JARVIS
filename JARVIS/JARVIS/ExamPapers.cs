using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace JARVIS
{
    public class ExamPapers
    {
        public void getPapers(string subject)
        {
            switch (subject)
            {
                case ("Accounting"):
                    accountsPapers();
                    break;
                case ("Computing"):
                    computingPapers();
                    break;
                case ("Maths"):
                    mathsPapers();
                    break;
            }
        }

        public void accountsPapers()
        {
            string template = "http://filestore.aqa.org.uk/subjects/AQA-ACCN3-QP-";
            string secondTemplate = "http://filestore.aqa.org.uk/subjects/AQA-ACCN3-W-QP-";
            string accn4Template = "http://filestore.aqa.org.uk/subjects/AQA-ACCN4-QP-";
            string accn4SecondTemplate = "http://filestore.aqa.org.uk/subjects/AQA-ACCN4-W-QP-";
            string[] years = { "JAN13", "JUN12", "JAN12", "JUN11", "JAN11", "JUN10" };
            string endingForURL = ".PDF";
            string endingForSave = ".pdf";

            Console.WriteLine("Attempting to download:");
            for (int i = 0; i <= years.Length - 1; i++)
            {
                string downloadURL = template + years[i] + endingForURL;
                string savePath = "C:\\Users\\(Insert local username here)\\Desktop\\Exam Papers\\Accounts\\" + years[i] + " ACCN3" + endingForSave;

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadURL, savePath);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }

                var file = new FileInfo(savePath);
                int fileSize = (int)file.Length / 1024;

                if (fileSize == 21)
                {
                    File.Delete(savePath);
                    downloadURL = secondTemplate + years[i] + endingForURL;
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("ACCN 3 " + years[i] + endingForSave);
                            webClient.DownloadFile(downloadURL, savePath);
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("ACCN 3 " + years[i] + endingForSave);
                }
                //....................................................................................................................

                downloadURL = accn4Template + years[i] + endingForURL;
                savePath = "C:\\Users\\(Insert local username here)\\Desktop\\Exam Papers\\Accounts\\" + years[i] + " ACCN4" + endingForSave;

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadURL, savePath);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }

                file = new FileInfo(savePath);
                fileSize = (int)file.Length / 1024;

                if (fileSize == 21)
                {
                    File.Delete(savePath);
                    downloadURL = accn4SecondTemplate + years[i] + endingForURL;
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("ACCN 4 " + years[i] + endingForSave);
                            webClient.DownloadFile(downloadURL, savePath);
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("ACCN 4 " + years[i] + endingForSave);
                }
            }
            Console.WriteLine("Downloads Complete");
        }

        public void computingPapers()
        {
            string template = "http://filestore.aqa.org.uk/subjects/AQA-COMP3-QP-";
            string secondTemplate = "http://filestore.aqa.org.uk/subjects/AQA-COMP3-W-QP-"; ;
            string[] years = { "JUN12", "JUN11", "JUN10" };
            string endingForURL = ".PDF";
            string endingForSave = ".pdf";

            Console.WriteLine("Attempting to download:");
            for (int i = 0; i <= years.Length - 1; i++)
            {
                string downloadURL = template + years[i] + endingForURL;
                string savePath = "C:\\Users\\(Insert local username here)\\Desktop\\Exam Papers\\Computing\\" + years[i] + " COMP3" + endingForSave;

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadURL, savePath);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }

                var file = new FileInfo(savePath);
                int fileSize = (int)file.Length / 1024;

                if (fileSize == 21)
                {
                    File.Delete(savePath);
                    downloadURL = secondTemplate + years[i] + endingForURL;
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("COMP 3 " + years[i] + endingForSave);
                            webClient.DownloadFile(downloadURL, savePath);
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("COMP 3 " + years[i] + endingForSave);
                }

            }
            Console.WriteLine("Downloads Complete");
        }

        public void mathsPapers()
        {
            string template = "http://filestore.aqa.org.uk/subjects/AQA-MPC3-QP-";
            string secondTemplate = "http://filestore.aqa.org.uk/subjects/AQA-MPC3-W-QP-";
            string mpc4Template = "http://filestore.aqa.org.uk/subjects/AQA-MPC4-QP-";
            string mpc4SecondTemplate = "http://filestore.aqa.org.uk/subjects/AQA-MPC4-W-QP-";
            string[] years = { "JAN13", "JUN12", "JAN12", "JUN11", "JAN11", "JUN10" };
            string endingForURL = ".PDF";
            string endingForSave = ".pdf";

            Console.WriteLine("Attempting to download:");
            for (int i = 0; i <= years.Length - 1; i++)
            {
                string downloadURL = template + years[i] + endingForURL;
                string savePath = "C:\\Users\\(Insert local username here)\\Desktop\\Exam Papers\\Maths\\" + years[i] + " MPC3" + endingForSave;

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadURL, savePath);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }

                var file = new FileInfo(savePath);
                int fileSize = (int)file.Length / 1024;

                if (fileSize == 21)
                {
                    File.Delete(savePath);
                    downloadURL = secondTemplate + years[i] + endingForURL;
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("MPC 3 " + years[i] + endingForSave);
                            webClient.DownloadFile(downloadURL, savePath);
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("MPC 3 " + years[i] + endingForSave);
                }
                //....................................................................................................................

                downloadURL = mpc4Template + years[i] + endingForURL;
                savePath = "C:\\Users\\(Insert local username here)\\Desktop\\Exam Papers\\Maths\\" + years[i] + " MPC4" + endingForSave;

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadURL, savePath);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }

                file = new FileInfo(savePath);
                fileSize = (int)file.Length / 1024;

                if (fileSize == 21)
                {
                    File.Delete(savePath);
                    downloadURL = mpc4SecondTemplate + years[i] + endingForURL;
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("MPC 4 " + years[i] + endingForSave);
                            webClient.DownloadFile(downloadURL, savePath);
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("MPC 4 " + years[i] + endingForSave);
                }
            }
            Console.WriteLine("Downloads Complete");
        }
    }
}

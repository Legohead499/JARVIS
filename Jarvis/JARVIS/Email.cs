using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Threading;

namespace JARVIS
{
    public class Email
    {
        Application outLookApp = new Application();

        public void openMail()
        {
            Process.Start("outlook.exe");
            NameSpace outlookNameSpace = outLookApp.GetNamespace("MAPI");
            outlookNameSpace.SendAndReceive(false);
            MAPIFolder inbox = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);


            int newMail = inbox.UnReadItemCount;
            string emailMessage = "";
            if (newMail == 0)
            {
                emailMessage = ("Openning Outlook, you have no new emails");
            }
            else if (newMail == 1)
            {
                emailMessage = ("Openning Outlook, you have one new email");
            }
            else
            {
                emailMessage = ("Openning Outlook, you have " + newMail + " new  emails");
            }
            using (SpeechSynthesizer sayOpenMail = new SpeechSynthesizer())
            {
                sayOpenMail.Speak(emailMessage);
            }
        }

        //load sendMailItem form
        //grab info
        //say send
        SpeechRecognitionEngine waitForSend = new SpeechRecognitionEngine();
        sendMailInput mailPreview = new sendMailInput();
        public void sendMail()
        {
            mailPreview.Show();
            Jarvis.myVoice.RecognizeAsyncStop();
            waitForSend.SetInputToDefaultAudioDevice();
            waitForSend.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(Jarvis.getPhrases()))));
            waitForSend.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(waitForSend_SpeechRecognized);
            waitForSend.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void waitForSend_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToUpper().Equals("SEND"))
            {
                MailItem myMail = (MailItem)outLookApp.CreateItem(OlItemType.olMailItem);
                string[] recipients = new string[20];
                string subject = "";
                string body = "";
                using (SpeechSynthesizer sendMail = new SpeechSynthesizer())
                {

                    recipients = mailPreview.sendTo();

                    subject = mailPreview.subject();

                    body = mailPreview.getMessage();

                    sendMail.Speak("Sending Mail");

                    myMail.To = recipients[0];

                    //check for more                    
                    if (recipients[1] != null)
                    {
                        for (int index = 1; index <= recipients.Length - 1; index++)
                        {
                            if (recipients[index] != null)
                            {
                                myMail.Recipients.Add(recipients[index]);
                            }
                        }
                    }
                    
                    myMail.Subject = subject;
                    myMail.Body = body;
                    myMail.Send();
                    sendMail.Speak("Sent");
                    sendMail.Volume = 0;


                    for (int index = 0; index <= recipients.Length - 1; index++)
                    {
                        recipients[index] = null;
                    }
                    subject = "";
                    body = "";
                    myMail = null;
                }
                try
                {
                    Jarvis.myVoice.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch(System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                mailPreview.Close();

                waitForSend.RecognizeAsyncStop();
            }
            
        }

        public void readMail()
        {
            bool outlookOpen = false;
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process item in allProcesses)
            {
                if (item.ProcessName.ToString().ToLower().Equals("outlook"))
                {
                    outlookOpen = true;
                }
            }

            if (!outlookOpen)
            {
                Process.Start("outlook.exe");
            }

            try
            {
                NameSpace outlookNameSpace = outLookApp.GetNamespace("MAPI");
                outlookNameSpace.SendAndReceive(false);
                MAPIFolder inbox = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

                int amountToRead = 5;
                int amountOfMail = inbox.Items.Count;

                if (amountOfMail != 0)
                {
                    if (amountOfMail < amountToRead)
                    {
                        amountToRead = amountOfMail;
                        Console.WriteLine(amountToRead.ToString());
                    }                   

                    for (int i = 0; i < amountToRead; i++)
                    {
                        MailItem email = inbox.Items[amountToRead - i];
                        string sender = email.SenderEmailAddress;

                        string subject = email.Subject;

                        string body = email.Body;
                        if(body.Contains("HYPERLINK"))
                        {
                            using(SpeechSynthesizer tooLong = new SpeechSynthesizer())
                            {
                                tooLong.Speak("Email too long to repeat");
                            }
                        }
                        else
                        {
                            using(SpeechSynthesizer readingMail = new SpeechSynthesizer())
                            {
                                readingMail.Speak("Message From: " + sender + ", Message Subject: " + subject +", Message: " + body);
                            }
                        }

                    }
                }
                else
                {
                    using (SpeechSynthesizer noMail = new SpeechSynthesizer())
                    {
                        noMail.Speak("No mail in inbox");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("DONE");
        }
    }
}

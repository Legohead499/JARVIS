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


            int newMail = inbox.Items.Count;
            string emailMessage = "";
            if (newMail == 0)
            {
                emailMessage = ("Openning Outlook, you have no emails");
            }
            else if (newMail == 1)
            {
                emailMessage = ("Openning Outlook, you have one email");
            }
            else
            {
                emailMessage = ("Openning Outlook, you have " + newMail + "  emails");
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
    }
}

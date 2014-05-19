using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using CursProject.Doc;
using D.Net.EmailClient;
using D.Net.EmailInterfaces;
using Limilabs.Client.IMAP;
using Limilabs.Client.POP3;
using Limilabs.Mail;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Properties;

namespace PhoneAnalyzer.Helpers
{
    internal class Mailer
    {
        internal static void SendReport(Subdivision sub, DateTime dateFrom, DateTime dateTo, string fileName)
        {
            var text = string.Format("Здравствуйте {0}!\r\nВ письме содержатся затраты на связь c {1} по {2}", sub.DirectorFio, dateFrom, dateTo);
            var theme = string.Format("Затраты на связь c {0} по {1}", dateFrom, dateTo);

            SendMail(sub.Email, theme, text, fileName);
        }

        internal static void SendReport(string finMail, DateTime dateFrom, DateTime dateTo, string fileName)
        {
            var text = string.Format("Здравствуйте {0}!\r\nВ письме содержатся затраты на связь c {1} по {2}", finMail, dateFrom, dateTo);
            var theme = string.Format("Затраты на связь c {0} по {1}", dateFrom, dateTo);

            SendMail(finMail, theme, text, fileName);
        }

        public static void SendMail(string mailFrom, string theme, string text, string fileName = "")
        {
            var smtpClient = new SmtpClient
            {
                Port = Setting.Port, // 587
                Host = Setting.Host, // "smtp.gmail.com"
                EnableSsl = true,
                Timeout = 60000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(Setting.Login, Setting.Password)
            };

            var mm = new MailMessage(Setting.Login, mailFrom, theme, text)
            {
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            if (fileName != "")
            {
                var attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(fileName);
                disposition.ModificationDate = File.GetLastWriteTime(fileName);
                disposition.ReadDate = File.GetLastAccessTime(fileName);
                disposition.FileName = Path.GetFileName(fileName);
                disposition.Size = new FileInfo(fileName).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                mm.Attachments.Add(attachment);
            }

            smtpClient.Send(mm);
        }

        public static void GetMails()
        {
            IEmailClient ImapClient = EmailClientFactory.GetClient(EmailClientEnum.IMAP);
            ImapClient.Connect(Setting.PopHost, Setting.Login, Setting.Password, Setting.PopPort, true);
            ImapClient.SetCurrentFolder("INBOX");
            ImapClient.LoadRecentMessages(5);
            // To read all my messages loaded:
            for (int i = 0; i < ImapClient.Messages.Count; i++)
            {
                IEmail msm = (IEmail)ImapClient.Messages[i];
                // Load all infos include attachments
                msm.LoadInfos();
                if (msm.Subject.ToLower().Contains("callsnew"))
                {
                    foreach (var att in msm.Attachments)
                    {
                        if (!Directory.Exists(Application.StartupPath + "\\MailFiles"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\MailFiles");
                        }

                        var fileName = Application.StartupPath + "\\MailFiles\\CallsFromEmail" + Guid.NewGuid().ToString().Replace("-", "") + ".xls";
                        File.WriteAllBytes(fileName, att.Body);

                        ExcelLoader.LoadCalls(fileName);
                        File.Delete(fileName);
                    }
                }

                if (msm.Subject.ToLower().Contains("atccalls"))
                {
                    foreach (var att in msm.Attachments)
                    {
                        if (!Directory.Exists(Application.StartupPath + "\\MailFiles"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\MailFiles");
                        }

                        var fileName = Application.StartupPath + "\\MailFiles\\AtcCallsFromEmail" + Guid.NewGuid().ToString().Replace("-", "") + ".xls";
                        File.WriteAllBytes(fileName, att.Body);

                        ExcelLoader.LoadAtcCalls(fileName);
                        File.Delete(fileName);
                    }
                }
            }
        }
    }
}
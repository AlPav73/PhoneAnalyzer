using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Helpers
{
    internal class MailSender
    {
        internal static void SendReport(Subdivision sub, DateTime dateFrom, DateTime dateTo, string fileName)
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
            var text = string.Format("Здравствуйте {0}!\r\nВ письме содержатся затраты на связь c {1} по {2}", sub.DirectorFio, dateFrom, dateTo);
            var mm = new MailMessage(Setting.Login, sub.Email, string.Format("Затраты на связь c {0} по {1}", dateFrom, dateTo), text)
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

        internal static void SendReport(string finMail, DateTime dateFrom, DateTime dateTo, string fileName)
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
            var text = string.Format("Здравствуйте {0}!\r\nВ письме содержатся затраты на связь c {1} по {2}", finMail, dateFrom, dateTo);
            var mm = new MailMessage(Setting.Login, finMail, string.Format("Затраты на связь c {0} по {1}", dateFrom, dateTo), text)
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
    }
}
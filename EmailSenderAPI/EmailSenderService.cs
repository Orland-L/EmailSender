using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace EmailSenderAPI
{
    //public record EmailSenderCredential(string Host, string Email, string Password, int Port, bool EnableSsl);

    public class EmailSenderService
    {
        private readonly EmailSenderCredential _credential;
        private readonly ILogger<EmailSenderService> _logger;
        private readonly string _loggingTemplate = " Sender: {0}\n Recipient: {1}\n Subject: {2}\n Body: {3}\n Date: {4}\n Send Attempt: {5}\n Status: {6}\n\n";
        private const int _maxRetryAttempts = 3;

        public EmailSenderService(EmailSenderCredential credential, ILogger<EmailSenderService> logger)
        {
            _credential = credential;
            _logger = logger;
        }

        public void SendMail(string recipient, string subject, string body)
        {
            SendMail(recipient, subject, body, 1);
        }

        public async Task SendMailAsync(string recipient, string subject, string body)
        {
            await SendMailAsync(recipient, subject, body, 1);
        }

        private void SendMail(string recipient, string subject, string body, int sendAttempt)
        {
            var message = new MailMessage(_credential.Email, recipient, subject, body);
            try
            {
                using var smtpClient = new SmtpClient(_credential.Host, _credential.Port);
                smtpClient.Credentials = new NetworkCredential(_credential.Email, _credential.Password);
                smtpClient.EnableSsl = _credential.EnableSsl;
                smtpClient.Send(message);
                LogMail(message, sendAttempt, true);
            }
            catch (Exception ex)
            {
                LogMail(message, sendAttempt, false);
                if (sendAttempt < _maxRetryAttempts)
                {
                    Thread.Sleep(5000);
                    SendMail(recipient, subject, body, ++sendAttempt);
                }
                throw new EmailSendException(ex.Message);
            }
        }
        private async Task SendMailAsync(string recipient, string subject, string body, int sendAttempt)
        {
            var message = new MailMessage(_credential.Email, recipient, subject, body);
            try
            {
                using var smtpClient = new SmtpClient(_credential.Host, _credential.Port);
                smtpClient.Credentials = new NetworkCredential(_credential.Email, _credential.Password);
                smtpClient.EnableSsl = _credential.EnableSsl;
                await smtpClient.SendMailAsync(message);
                LogMail(message, sendAttempt, true);
            }
            catch (Exception ex)
            {
                LogMail(message, sendAttempt, false);
                if(sendAttempt < _maxRetryAttempts)
                {
                    await Task.Delay(5000);
                    await SendMailAsync(recipient, subject, body, ++sendAttempt);
                }
                throw new EmailSendException(ex.Message);
            }
        }

        private void LogMail(MailMessage message, int sendAttempt, bool isSent)
        {
            string log = String.Format(_loggingTemplate, message.From, message.To, message.Subject, message.Body,
                DateTime.Now.ToString(), sendAttempt, isSent ? "Success" : "Failure");
            _logger.LogInformation(log);
            File.AppendAllText("email_log.txt", log);
        }
    }
}

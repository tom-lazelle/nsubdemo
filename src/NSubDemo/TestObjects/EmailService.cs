using System;

namespace NSubDemo.TestObjects
{
    public class EmailService
    {
        private readonly INetworkRelay _networkRelay;

        public EmailService(INetworkRelay networkRelay)
        {
            _networkRelay = networkRelay;
        }

        public void SendEmail(string to, string from, string subject, string body)
        {
            if(string.IsNullOrEmpty(to)) throw new Exception("to is required");

            _networkRelay.Send(to,from,subject,body);
        }
    }

    public interface INetworkRelay
    {
        void Send(string to, string from, string subject, string body);
    }
}
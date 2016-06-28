using System;
using NSubDemo.TestObjects;
using NSubstitute;
using Should;

namespace NSubDemo.NSubDemo
{
    public class nsub_demo_5_test
    {
        public void void_sub()
        {
            var mailSent = false;

            var networkRelay = Substitute.For<INetworkRelay>();

            networkRelay
                .When(x=>x.Send(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()))
                .Do(x =>
                {
                    mailSent = true;
                    Console.WriteLine($"To:{x.ArgAt<string>(0)}|From:{x.ArgAt<string>(1)}|Subject:{x.ArgAt<string>(2)}|Body:{x.ArgAt<string>(3)}");

                });


            var service = new EmailService(networkRelay);

            service.SendEmail("test", "test", "test", "test");

            mailSent.ShouldBeTrue();
        }
    }
}
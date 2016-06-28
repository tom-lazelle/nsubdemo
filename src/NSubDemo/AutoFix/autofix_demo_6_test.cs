using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_6_test
    {
        public void freeze_customer()
        {
            var fixture = new Fixture();

            fixture.Freeze<Customer>();

            var customer1 = fixture.Create<Customer>();

            var customer2 = fixture.Create<Customer>();

            customer1.Id.ShouldEqual(customer2.Id);
            customer1.Name.ShouldEqual(customer2.Name);
        }
    }
}
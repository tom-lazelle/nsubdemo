using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_2_test
    {
        public void create_customer()
        {

            var fixture = new Fixture();

            var customer = fixture.Create<Customer>();

            customer.ShouldNotBeNull();
            customer.Id.ShouldBeGreaterThan(0);
            customer.Name.ShouldNotBeNull();
        }
    }
}
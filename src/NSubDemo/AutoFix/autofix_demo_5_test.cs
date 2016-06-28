using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_5_test
    {
        public void builder()
        {
            var fixture = new Fixture();

            var customer1 = fixture.Build<Customer>()
                .With(x => x.Id)
                .With(x => x.Name)
                .Create();

            var customer2 = fixture.Build<Customer>()
                .With(x => x.Id)
                .Without(x => x.Name)
                .Create();

            customer1.Id.ShouldBeGreaterThan(0);
            customer1.Name.ShouldNotBeNull();

            customer2.Id.ShouldBeGreaterThan(0);
            customer2.Name.ShouldBeNull();
        }
    }
}
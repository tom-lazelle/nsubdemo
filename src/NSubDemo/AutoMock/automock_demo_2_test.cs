using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Should;

namespace NSubDemo.AutoMock
{
    public class automock_demo_2_test
    {
        public void sut_with_customer_test()
        {
            var fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());

            fixture.Register(() => new Customer
            {
                Id = 1,
                Name = "zippy"
            });

            var repo = fixture.Create<CustomerRepository>();

            var result = repo.Get(1);

            result.ShouldNotBeNull();

            result.Name.ShouldEqual("zippy");
        }
    }
}
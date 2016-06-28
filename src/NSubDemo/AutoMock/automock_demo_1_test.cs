using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Should;

namespace NSubDemo.AutoMock
{
    public class automock_demo_1_test
    {
        public void subject_under_test()
        {

            var fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());

            var repo = fixture.Create<CustomerRepository>();

            var result = repo.Get(1);

            result.ShouldNotBeNull();
        }
    }
}
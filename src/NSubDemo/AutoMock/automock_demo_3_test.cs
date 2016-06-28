using NSubDemo.TestObjects;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Should;

namespace NSubDemo.AutoMock
{
    public class automock_demo_3_test
    {
        public void sut_with_datasource_test()
        {
            var fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());

            var mockProvider = Substitute.For<IDataSource<Customer>>();

            mockProvider.Get(1).Returns(fixture.Create<Customer>());

            fixture.Register(() => mockProvider);

            var repo = fixture.Create<CustomerRepository>();

            var result = repo.Get(1);

            result.ShouldNotBeNull();
        }
    }
}
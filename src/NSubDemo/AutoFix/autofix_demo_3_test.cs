using NSubDemo.TestObjects;
using NSubstitute;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_3_test
    {
        public void register_types_customer()
        {
            var mockDataSource = Substitute.For<IDataSource<Customer>>();

            var fixture = new Fixture();

            fixture.Register<IDataSource<Customer>>(() => mockDataSource);

            var repository = fixture.Create<CustomerRepository>();

            repository.ShouldNotBeNull();
        }
    }
}
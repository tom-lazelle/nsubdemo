using NSubDemo.TestObjects;
using NSubstitute;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoMock
{
    public class sut_with_datasource_test : SubjectTestFor<CustomerRepository>
    {
        public void get_a_customer()
        {
            var ds = MockType<IDataSource<Customer>>();
            ds.Get(1).Returns(_fixture.Create<Customer>());

            Register(ds);

            var result = sut.Get(1);

            result.ShouldNotBeNull();
            ds.Received(1).Get(1);
        }
    }
}
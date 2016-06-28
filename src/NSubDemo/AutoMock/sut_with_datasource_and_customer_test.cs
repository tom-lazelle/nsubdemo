using NSubDemo.TestObjects;
using NSubstitute;
using Should;

namespace NSubDemo.AutoMock
{
    public class sut_with_datasource_and_customer_test : SubjectTestFor<CustomerRepository>
    {
        public void get_a_customer()
        {
            var ds = MockType<IDataSource<Customer>>();
            ds.Get(1).Returns(new Customer
            {
                Id = 1,
                Name = "zippy"
            });

            Register(ds);

            var result = sut.Get(1);

            result.ShouldNotBeNull();
            ds.Received(1).Get(1);
            result.Name.ShouldEqual("zippy");
        }
    }
}
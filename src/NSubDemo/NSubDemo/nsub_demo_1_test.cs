using NSubDemo.TestObjects;
using NSubstitute;
using Should;

namespace NSubDemo.NSubDemo
{
    public class nsub_demo_1_test
    {
        public void simple_subs()
        {
            var dataSource = Substitute.For<IDataSource<Customer>>();

            dataSource.Get(1).Returns(new Customer
            {
                Id = 1,
                Name = "Skippy"
            });

            var repo = new CustomerRepository(dataSource);

            var result = repo.Get(1);

            result.ShouldNotBeNull();
        }
    }
}
using NSubDemo.TestObjects;
using NSubstitute;
using Should;

namespace NSubDemo.NSubDemo
{
    public class nsub_demo_2_test
    {
        public void simple_with_args_sub(){
            var dataSource = Substitute.For<IDataSource<Customer>>();

            dataSource.Get(Arg.Any<int>()).Returns(new Customer
            {
                Id = 1,
                Name = "Skippy"
            });

            var repo = new CustomerRepository(dataSource);

            var result = repo.Get(99);

            result.ShouldNotBeNull();
        }
    }
}
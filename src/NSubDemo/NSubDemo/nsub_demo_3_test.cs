using NSubDemo.TestObjects;
using NSubstitute;
using Should;

namespace NSubDemo.NSubDemo
{
    public class nsub_demo_3_test
    {
        public void simple_return_with_args_sub()
        {
            var dataSource = Substitute.For<IDataSource<Customer>>();

            dataSource.Get(Arg.Any<int>())
                .ReturnsForAnyArgs(x=>
                new Customer
                {
                    Id = x.Arg<int>(),
                    Name = "skippy"
                });                

            var repo = new CustomerRepository(dataSource);

            var result = repo.Get(99);

            result.ShouldNotBeNull();
            result.Id.ShouldEqual(99);
        }
    }
}
using NSubDemo.TestObjects;
using Should;

namespace NSubDemo.AutoMock
{
    public class sut_with_customer_test : SubjectTestFor<CustomerRepository>
    {
        public void get_a_customer()
        {
            Register(new Customer
            {
                Id = 1,
                Name = "tom"
            });

            var result = sut.Get(1);

            result.ShouldNotBeNull();

            result.Name.ShouldEqual("tom");
        }
    }
}
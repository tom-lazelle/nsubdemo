using NSubDemo.TestObjects;
using Should;

namespace NSubDemo.AutoMock
{
    public class subject_under_test : SubjectTestFor<CustomerRepository>
    {
        public void get_a_customer()
        {
            var result = sut.Get(1);

            result.ShouldNotBeNull();
        }
    }
}
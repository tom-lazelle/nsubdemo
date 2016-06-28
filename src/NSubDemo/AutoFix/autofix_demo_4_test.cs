using System.Linq;
using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_4_test
    {
        public void list_of_customers_customer()
        {
            var fixture = new Fixture();

            var listOf = fixture.CreateMany<Customer>(10);

            listOf.Count().ShouldEqual(10);
        }
    }
}
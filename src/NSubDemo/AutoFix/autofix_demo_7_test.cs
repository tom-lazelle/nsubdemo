using System.Reflection;
using NSubDemo.TestObjects;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_7_test
    {
        public void specimen()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new NameSpecimen());

            var customer = fixture.Create<Customer>();

            customer.Name.ShouldEqual("Skippy");
        }
        public class NameSpecimen : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                
                var pi = request as PropertyInfo;

                if (pi == null  || pi.PropertyType != typeof(string) || pi.Name != "Name")
                {
                    return new NoSpecimen();
                }

                return "Skippy";
            }
        }
    }
}
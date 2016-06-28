using System;
using Ploeh.AutoFixture;
using Should;

namespace NSubDemo.AutoFix
{
    public class autofix_demo_1_test
    {
        public void random_value()
        {

            var fixture = new Fixture();

            var number = fixture.Create<int>();
            var stringValue = fixture.Create<string>();
            var guidValue = fixture.Create<Guid>();

            number.ShouldBeGreaterThan(0);
            stringValue.ShouldNotBeNull();
            guidValue.ShouldBeType(typeof(Guid));
        }
    }
}
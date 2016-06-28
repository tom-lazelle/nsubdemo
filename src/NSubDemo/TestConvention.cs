using System;
using System.Reflection;
using Fixie;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Fixture = Fixie.Fixture;

namespace NSubDemo
{
    public class TestConvention : Convention
    {
        public TestConvention()
        {
            FixtureExecution.Wrap<FixtureSetupBehavior>();

            Classes.NameEndsWith("test", "Test");

            Methods
               .Where(x =>
                x.IsVoid() &&
                x.IsPublic &&
                x.Name != "FixtureSetup" &&
                x.Name != "FixtureTearDown");

            ClassExecution
                .CreateInstancePerClass();

        }
    }

    public class FixtureSetupBehavior : FixtureBehavior
    {
        public void Execute(Fixture context, Action next)
        {
            var fixture = new Ploeh.AutoFixture.Fixture().Customize(new AutoConfiguredNSubstituteCustomization());

            context.Instance.GetType().TryInvoke("FixtureSetup", context.Instance, new object[]
            {
                fixture
            });

            next();

            context.Instance.GetType().TryInvoke("FixtureTearDown", context.Instance);
        }
    }

    public static class BehaviorBuilderExtensions
    {
        public static void TryInvoke(this Type type, string method, object instance, object[] paramObjects = null)
        {
            var lifecycleMethod = type.GetMethod(method);

            if (lifecycleMethod == null)
                return;

            try
            {
                lifecycleMethod.Invoke(instance, paramObjects);
            }
            catch (TargetInvocationException exception)
            {
                throw new PreservedException(exception.InnerException);
            }
        }
    }

    public interface IBaseTest
    {
        void FixtureSetup(IFixture fixture);
        void FixtureTearDown();
    }

    public abstract class SubjectTestFor<TClassUnderTest> : IBaseTest where TClassUnderTest : class
    {
        protected IFixture _fixture;

        protected TClassUnderTest sut => new Lazy<TClassUnderTest>(_fixture.Create<TClassUnderTest>).Value;

        protected void Register<TInterface>(TInterface concreteType)
        {
            _fixture.Register(() => concreteType);
        }

        protected T MockType<T>() where T : class
        {
            return Substitute.For<T>();
        }

        public virtual void FixtureSetup(IFixture fixture)
        {
            _fixture = fixture;
        }

        public virtual void FixtureTearDown()
        {

        }
    }
}
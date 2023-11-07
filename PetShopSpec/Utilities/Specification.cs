using System;
using Machine.Specifications;
using Moq;
using Moq.AutoMock;

namespace Training.Specificaton
{
    public class Specification<TSystemUnderTest> where TSystemUnderTest : class
    {
        protected static AutoMocker container;

        private Establish context = () => { container = new AutoMocker(); };

        public static TSystemUnderTest subject
        {
            get { return container.Get<TSystemUnderTest>(); }
        }

        protected Mock<InterfaceType> Dependency<InterfaceType>() where InterfaceType : class
        {
            InterfaceType mock = container.Get<InterfaceType>();
            return Moq.Mock.Get(mock);
        }

        public static void ProvideBasicConstructorArgument<TInterface>(TInterface instance) where TInterface : class =>
            container.Use<TInterface>(instance);

        public static void ProvideAnImplementationOf<TInterface>(TInterface instance) =>
            container.Use<TInterface>(instance);
    }
}
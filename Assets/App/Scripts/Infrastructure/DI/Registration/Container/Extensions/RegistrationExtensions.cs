using System;

namespace App.Scripts.Infrastructure.DI.Registration.Container.Extensions
{
    public static class RegistrationExtensions
    {
        private static RegistrationBuilder Register(
            this IRegistrationContainer container
            , Type implementationType) =>
            container.Register(new RegistrationBuilder(implementationType));
    
        private static RegistrationBuilder Register(
            this IRegistrationContainer container
            , Type interfaceType
            , Type implementationType) =>
            container.Register(implementationType).As(interfaceType);
    
        public static RegistrationBuilder Register<T>(
            this IRegistrationContainer container) =>
            container.Register(typeof(T), typeof(T));
        public static RegistrationBuilder Register<TInterface, TImplementation>(
            this IRegistrationContainer container) where TImplementation : TInterface =>
            container.Register(typeof(TInterface), typeof(TImplementation));

        public static RegistrationBuilder WithArguments(this RegistrationBuilder builder, params object[] arguments)
        {
            builder.AddArguments(arguments);
            return builder;
        }
    }
}

namespace App.Scripts.Infrastructure.DI.Registration.Container
{
    public interface IRegistrationContainer
    {
        T Register<T>(T registrationBuilder) where T : RegistrationBuilder;
        T Resolve<T>() where T : class;
        RegistrationData CurrentRegistrationData { get; }
        void BuildContainer();
        T Create<T>() where T : class;
    }
}
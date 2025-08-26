using App.Scripts.Infrastructure.DI.Registration.Container;

namespace App.Scripts.Infrastructure.DI.Installers
{
    public interface IInstaller
    {
        public void Configure(IRegistrationContainer container);
    }
}
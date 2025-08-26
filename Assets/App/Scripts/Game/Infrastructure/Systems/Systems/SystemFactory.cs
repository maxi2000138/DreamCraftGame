using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;
using App.Scripts.Infrastructure.DI.Registration.Container;

namespace App.Scripts.Game.Infrastructure.Systems.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly IRegistrationContainer _registrationContainer;
    public SystemFactory(IRegistrationContainer registrationContainer)
    {
      _registrationContainer = registrationContainer;
    }

    ISystem ISystemFactory.Create<T>()
    {
      return _registrationContainer.Create<T>();
    }
  }
}
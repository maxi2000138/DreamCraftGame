using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;
using MyContainer.Container;

namespace App.Scripts.Game.Infrastructure.Systems.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly IRegistrationContainer _registrationContainer;
    public SystemFactory(IRegistrationContainer registrationContainer)
    {
      _registrationContainer = registrationContainer;
    }
    
    public ISystem Create<T>() where T : class, ISystem, new()
    {
      return _registrationContainer.Create<T>();
    }
  }
}
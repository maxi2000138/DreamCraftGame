using App.Scripts.Infrastructure.DI.Registration.Container;

namespace App.Scripts.Infrastructure.DI.Scopes
{
  public abstract class LifetimeScopeProject : LifetimeScope
  {
    protected override void AfterInitialize(IRegistrationContainer container)
    {
      base.AfterInitialize(container);
      DontDestroyOnLoad(this);
    }
  }
}

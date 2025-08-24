using MyContainer.Container;
namespace Scopes
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

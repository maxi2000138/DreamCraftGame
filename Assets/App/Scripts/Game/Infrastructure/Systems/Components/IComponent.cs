using R3;

namespace App.Scripts.Game.Infrastructure.Systems.Components
{ 
  public interface IComponent
  {
    CompositeDisposable LifetimeDisposable { get; }

    void OnComponentCreate();
    void OnComponentEnable();
    void OnComponentDisable();
    void OnComponentDestroy();
  }
}
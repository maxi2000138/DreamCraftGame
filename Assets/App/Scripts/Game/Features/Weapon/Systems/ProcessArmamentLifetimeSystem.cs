using System;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using R3;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class ProcessArmamentLifetimeSystem : SystemComponent<ArmamentComponent>
  {
    protected override void OnEnableComponent(ArmamentComponent component)
    {
      base.OnEnableComponent(component);
      
      component.Spawned.Subscribe(_ => {
        Observable.Interval(TimeSpan.FromSeconds(component.Lifetime))
          .Subscribe(_ => component.Remove())
          .AddTo(component.LifetimeDisposable);
      })
        .AddTo(component.LifetimeDisposable);
    }
  }
}
using App.Scripts.Game.Features;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;
using MyContainer.Container;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.LifeTime
{
  public class GameScope : LifetimeScopeScene
  {
    [SerializeField] private GameEntryPoint _gameEntryPoint;

    public override void Configure(IRegistrationContainer container)
    {
      container.Register<IRegistrationContainer>().FromInstance(container);
      
      container.Register<ISystemFactory, SystemFactory>();
      container.Register<SystemsContainer>();
      
      container.Register<BattleFeature>();
    }
    
    protected override void AfterInitialize(IRegistrationContainer container)
    {
      base.AfterInitialize(container);
      
      _gameEntryPoint.Construct(container.Resolve<SystemsContainer>());
      _gameEntryPoint.Entry();
    }
  }
}

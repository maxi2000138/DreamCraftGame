using App.Scripts.Game.Features;
using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Features.Weapon.Factory;
using App.Scripts.Game.Features.Weapon.Variations;
using App.Scripts.Game.Infrastructure.Factory;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;
using App.Scripts.Infrastructure.DI.Registration.Container;
using App.Scripts.Infrastructure.DI.Registration.Container.Extensions;
using App.Scripts.Infrastructure.DI.Scopes;
using App.Scripts.Infrastructure.GUI.Factory;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.LifeTime
{
  public class GameScope : LifetimeScopeScene
  {
    [SerializeField] private GameEntryPoint _gameEntryPoint;

    public override void Configure(IRegistrationContainer container)
    {
      container.Register<IRegistrationContainer>().FromInstance(container);

      container.Register<IUnitMover, UnitMover>();
      container.Register<IGameFactory, GameFactory>();
      container.Register<IWeaponFactory, WeaponFactory>();
      
      container.Register<LevelModel>();

      container.Register<ISystemFactory, SystemFactory>();
      container.Register<SystemsContainer>();
      container.Register<BattleFeature>();
    }
    
    protected override void AfterInitialize(IRegistrationContainer container)
    {
      base.AfterInitialize(container);
      
      _gameEntryPoint.Construct(container.Resolve<SystemsContainer>(), container.Resolve<IUIFactory>(), 
        container.Resolve<LevelModel>());
      
      _gameEntryPoint.Entry();
    }
  }
}

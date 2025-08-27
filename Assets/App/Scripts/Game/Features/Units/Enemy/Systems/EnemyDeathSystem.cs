using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using R3;

namespace App.Scripts.Game.Features.Units.Enemy.Systems
{
  public class EnemyDeathSystem : SystemComponent<EnemyComponent>
  {
    private readonly LevelModel _levelModel;
    public EnemyDeathSystem(LevelModel levelModel)
    {
      _levelModel = levelModel;
    }
    
    protected override void OnEnableComponent(EnemyComponent component)
    {
      base.OnEnableComponent(component);
      
      component.Health.CurrentHealth
        .Skip(1)
        .Subscribe(_ => TryDeath(component))
        .AddTo(component.LifetimeDisposable);
    }
    
    private void TryDeath(EnemyComponent enemy)
    {
      if (enemy.Health.IsAlive == false)
      {
        _levelModel.RemoveEnemy(enemy);
        enemy.Remove();
      }
    }
  }
}
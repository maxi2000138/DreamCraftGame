using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Infrastructure.GUI.Factory;
using ObservableCollections;
using R3;

namespace App.Scripts.Game.Features.Units.Enemy.Systems
{
  public class EnemyHealthViewSpawnSystem : SystemComponent<EnemyHealthProviderComponent>
  {
    private readonly IUIFactory _uiFactory;
    private readonly LevelModel _levelModel;

    public EnemyHealthViewSpawnSystem(IUIFactory uiFactory, LevelModel levelModel)
    {
      _uiFactory = uiFactory;
      _levelModel = levelModel;
    }
    
    protected override void OnEnableComponent(EnemyHealthProviderComponent component)
    {
      base.OnEnableComponent(component);
      
      foreach (IEnemy enemy in _levelModel.Enemies) 
        CreateEnemyHealth(component, enemy);
      
      _levelModel.Enemies
        .ObserveAdd()
        .Subscribe(e => CreateEnemyHealth(component, e.Value))
        .AddTo(LifetimeDisposable);
    }
    
    private void CreateEnemyHealth(EnemyHealthProviderComponent component, IEnemy enemy)
    {
      EnemyHealthViewComponent enemyHealth = _uiFactory.CreateEnemyHealth(enemy, component.transform);
      enemyHealth.CanvasGroup.alpha = 0f;
    }

  }
}
using App.Scripts.Game.Features.Units.Enemy._Configs;
using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Data;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;

namespace App.Scripts.Game.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IObjectPoolService _poolService;
    private readonly IStaticDataService _staticData;
    private readonly LevelModel _levelModel;

    public GameFactory(IObjectPoolService poolService, IStaticDataService staticData, LevelModel levelModel)
    {
      _poolService = poolService;
      
      _staticData = staticData;
      _levelModel = levelModel;
    }
    
    public EnemyComponent CreateEnemy(EnemyType enemyType)
    {
      EnemyData enemyData = _staticData.EnemyConfig().Enemies[enemyType];
      
      EnemyComponent enemy = _poolService
        .SpawnObject(enemyData.Prefab)
        .GetComponent<EnemyComponent>();
      
      _levelModel.AddEnemy(enemy);
      
      enemy.CharacterController.SetSpeed(enemyData.Speed);
      
      return enemy;
    }
  }
}
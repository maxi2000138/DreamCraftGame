using App.Scripts.Game.Features.Units.Enemy._Configs;
using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Data;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IObjectPoolService _poolService;
    private readonly IStaticDataService _staticData;
    
    public GameFactory(IObjectPoolService poolService, IStaticDataService staticData)
    {
      _poolService = poolService;
      _staticData = staticData;
    }
    
    public EnemyComponent CreateEnemy(EnemyType enemyType)
    {
      EnemyData enemyData = _staticData.EnemyConfig().Enemies[enemyType];
      
      EnemyComponent enemy = _poolService
        .SpawnObject(enemyData.Prefab)
        .GetComponent<EnemyComponent>();
      
      enemy.CharacterController.SetSpeed(enemyData.Speed);
      
      return enemy;
    }
  }
}
using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Data;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Factory
{
  public interface IGameFactory
  {
    EnemyComponent CreateEnemy(EnemyType enemyType);
  }
}
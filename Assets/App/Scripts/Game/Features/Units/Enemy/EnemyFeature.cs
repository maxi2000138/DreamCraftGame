using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Systems;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;

namespace App.Scripts.Game.Features.Units.Enemy
{
  public class EnemyFeature : Feature
  {
    public EnemyFeature(ISystemFactory systems)
    {
      Add(systems.Create<EnemySpawnSystem>());
      Add(systems.Create<EnemyMoveToCharacterSystem>());
      Add(systems.Create<EnemyAttackCharacterSystem>());
      Add(systems.Create<EnemyDeathSystem>());
      
      Add(systems.Create<EnemyHealthViewSpawnSystem>());
      Add(systems.Create<EnemyHealthViewUpdateSystem>());
    }
  }
}
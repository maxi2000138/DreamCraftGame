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
    }
  }
}
using App.Scripts.Game.Features.Weapon.Systems;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;

namespace App.Scripts.Game.Features.Weapon
{
  public class WeaponFeature : Feature
  {
    public WeaponFeature(ISystemFactory systems)
    {
      Add(systems.Create<ExecuteWeaponSystem>());
      
      Add(systems.Create<ProcessEnemyCollisionArmamentSystem>());
    }
  }
}
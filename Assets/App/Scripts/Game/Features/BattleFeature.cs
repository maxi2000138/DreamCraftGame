using App.Scripts.Game.Features.Input;
using App.Scripts.Game.Features.Units.Character;
using App.Scripts.Game.Features.Units.Enemy;
using App.Scripts.Game.Features.Weapon;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;

namespace App.Scripts.Game.Features
{
  public class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      
      Add(systems.Create<CharacterFeature>());
      Add(systems.Create<EnemyFeature>());
      
      Add(systems.Create<WeaponFeature>());
    }
  }
}
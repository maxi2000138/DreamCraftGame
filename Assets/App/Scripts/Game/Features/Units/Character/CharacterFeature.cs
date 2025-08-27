using App.Scripts.Game.Features.Units.Character.Systems;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Game.Infrastructure.Systems.Systems.Factory;

namespace App.Scripts.Game.Features.Units.Character
{
  public class CharacterFeature : Feature
  {
    public CharacterFeature(ISystemFactory systems)
    {
      Add(systems.Create<CharacterInitializeSystem>());
      Add(systems.Create<CharacterMoveSystem>());
      Add(systems.Create<CharacterShootSystem>());
      
      Add(systems.Create<CharacterHealthViewUpdateSystem>());
    }
  }
}
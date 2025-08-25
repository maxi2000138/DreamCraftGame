using App.Scripts.Game.Features.Units.Character;
using R3;

namespace App.Scripts.Game
{
  public class LevelModel
  {
    public ICharacter Character { get; private set; }

    public void SetCharacter(ICharacter character) => Character = character;
  }
}
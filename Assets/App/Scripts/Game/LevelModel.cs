using App.Scripts.Game.Features.Units.Character.Interfaces;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using ObservableCollections;
using R3;

namespace App.Scripts.Game
{
  public class LevelModel
  {
    private ObservableList<IEnemy> _enemies = new ObservableList<IEnemy>();
      
    public ICharacter Character { get; private set; }
    public IReadOnlyObservableList<IEnemy> Enemies => _enemies;

    public ReactiveCommand StartGame { get; } = new ReactiveCommand();
    public ReactiveCommand EndGame { get; } = new ReactiveCommand();

    public void SetCharacter(ICharacter character) => Character = character;
    public void AddEnemy(IEnemy enemy) => _enemies.Add(enemy);
    public void RemoveEnemy(IEnemy enemy) => _enemies.Remove(enemy);
  }
}
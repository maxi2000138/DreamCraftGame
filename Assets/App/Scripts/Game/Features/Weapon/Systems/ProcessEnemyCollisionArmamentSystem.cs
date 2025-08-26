using App.Scripts.Game.Features.Units.Shared.Interfaces;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class ProcessEnemyCollisionArmamentSystem : SystemComponent<EnemyCollisionArmament>
  {
    private readonly LevelModel _levelModel;
    public ProcessEnemyCollisionArmamentSystem(LevelModel levelModel)
    {
      _levelModel = levelModel;
    }
    
    protected override void OnUpdate()
    {
      base.OnUpdate();
            
      Components.Foreach(CheckEnemyCollision);
      Components.Foreach(CheckCharacterCollision);
    }

    private void CheckEnemyCollision(EnemyCollisionArmament armament)
    {
      for (int i = 0; i < _levelModel.Enemies.Count; i++)
      {
        bool targetIsAlive = _levelModel.Enemies[i].Health.IsAlive;
        bool isCollision = (armament.Armament.Position - _levelModel.Enemies[i].Position).sqrMagnitude < armament.CollisionSqrDistance;

        if (targetIsAlive && isCollision)
        {
          Collision(armament, _levelModel.Enemies[i]);
        }
      }
    }

    private void CheckCharacterCollision(EnemyCollisionArmament armament)
    {
      bool targetIsAlive = _levelModel.Character.Health.IsAlive;
      bool isCollision = (armament.Armament.Position - _levelModel.Character.Position).sqrMagnitude < armament.CollisionSqrDistance;

      if (targetIsAlive && isCollision)
      {
        Collision(armament, _levelModel.Character);
      }
    }

    private void Collision(EnemyCollisionArmament armament, IUnit target)
    {
      target.Health.CurrentHealth.Value -= armament.Armament.Damage;

      armament.Armament.Remove();
    }
  }
}
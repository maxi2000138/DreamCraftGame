using App.Scripts.Game.Features.Units.Shared.Interfaces;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Collision;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class ProcessCollisionArmamentSystem : SystemComponent<CollisionArmament>
  {
    private readonly ICollisionService _collisionService;
    
    public ProcessCollisionArmamentSystem(ICollisionService collisionService)
    {
      _collisionService = collisionService;
    }
    
    protected override void OnUpdate()
    {
      base.OnUpdate();
            
      Components.Foreach(TryCollision);
    }
    
    private void TryCollision(CollisionArmament armament)
    {
      if (_collisionService.EnemyCollision(armament.Armament.Position, armament.CollisionSqrDistance, out var collision))
      {
        foreach (var target in collision) 
          Collision(armament, target);
      }
      
      if(_collisionService.CharacterCollision(armament.Armament.Position, armament.CollisionSqrDistance, out var characterCollision))
      {
        Collision(armament, characterCollision);
      }
    }



    private void Collision(CollisionArmament armament, IUnit target)
    {
      target.Health.CurrentHealth.Value -= armament.Armament.Damage;

      armament.Armament.Remove();
    }
  }
}
using App.Scripts.Game.Features.Units.Shared.Interfaces;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Components.Armaments;
using App.Scripts.Game.Infrastructure.Collision;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class TargetExplosionArmamentSystem : SystemComponent<TargetExplosionArmamentComponent>
  {
    private const float ExplosionEpsilon = 0.2f;
    
    private readonly ICollisionService _collisionService;
    public TargetExplosionArmamentSystem(ICollisionService collisionService)
    {
      _collisionService = collisionService;
    }
    
    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      Components.Foreach(TryExplode);
    }
    
    private void TryExplode(TargetExplosionArmamentComponent armamentComponent)
    {
      if((armamentComponent.Armament.Position - armamentComponent.TargetPosition).sqrMagnitude < ExplosionEpsilon)
      {

        if (_collisionService.EnemyCollision(armamentComponent.Armament.Position, armamentComponent.ExplosionSqrRadius, out var enemies))
        {
          foreach (var enemy in enemies) 
            Collision(armamentComponent, enemy);
        }
        
        if (_collisionService.CharacterCollision(armamentComponent.Armament.Position, armamentComponent.ExplosionSqrRadius, out var character))
        { 
          Collision(armamentComponent, character);
        }
        
        armamentComponent.Armament.Remove();
      }
    }
    
    private void Collision(TargetExplosionArmamentComponent armamentComponent, IUnit target)
    {
      target.Health.CurrentHealth.Value -= armamentComponent.Armament.Damage;
    }
  }
}
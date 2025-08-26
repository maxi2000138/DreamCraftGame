using App.Scripts.Game.Infrastructure.Systems.Components;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class EnemyCollisionArmament : MonoComponent<EnemyCollisionArmament>
  {
    public ArmamentComponent Armament { get; private set; }
    public float CollisionSqrDistance { get; private set; }
    
    public void Init(ArmamentComponent armament, float collisionSqrDistance)
    {
      Armament = armament;
      CollisionSqrDistance = collisionSqrDistance;
    }
  }
}
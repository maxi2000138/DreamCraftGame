using App.Scripts.Game.Infrastructure.Systems.Components;

namespace App.Scripts.Game.Features.Weapon.Components.Armaments
{
  public class CollisionArmament : MonoComponent<CollisionArmament>
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
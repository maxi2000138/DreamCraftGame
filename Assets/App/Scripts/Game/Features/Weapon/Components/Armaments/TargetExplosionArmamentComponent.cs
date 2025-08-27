using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class TargetExplosionArmamentComponent : MonoComponent<TargetExplosionArmamentComponent>
  {
    public ArmamentComponent Armament { get; private set; }
    public float ExplosionSqrRadius { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    
    public void Init(ArmamentComponent armament, float explosionSqrRadius, Vector3 targetPosition)
    {
      TargetPosition = targetPosition;
      Armament = armament;
      ExplosionSqrRadius = explosionSqrRadius;
    }
  }
}
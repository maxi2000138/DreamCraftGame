using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class TargetExplosionArmament : MonoComponent<TargetExplosionArmament>
  {
    public ArmamentComponent Armament { get; private set; }
    public float ExplosionRadius { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    
    public void Init(ArmamentComponent armament, float explosionRadius, Vector3 targetPosition)
    {
      TargetPosition = targetPosition;
      Armament = armament;
      ExplosionRadius = explosionRadius;
    }
  }
}
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class TrajectoryArmamentComponent : MonoComponent<TrajectoryArmamentComponent>
  {
    public ArmamentComponent Armament {get; private set;}
    public Vector3 TargetPosition { get; private set; }
    public float InitialSqrDistance { get; private set; }
    public float InitialHeight { get; private set; }
    public float ThrowHeight { get; private set; }
    public AnimationCurve ThrowCurve { get; private set; }
    
    public void Init(ArmamentComponent armament, Vector3 targetPosition, float throwHeight, 
      AnimationCurve throwCurve, float initialSqrDistance, float initialHeight)
    {
      Armament = armament;
      TargetPosition = targetPosition;
      ThrowHeight = throwHeight;
      ThrowCurve = throwCurve;
      InitialSqrDistance = initialSqrDistance;
      InitialHeight = initialHeight;
    }
  }
}
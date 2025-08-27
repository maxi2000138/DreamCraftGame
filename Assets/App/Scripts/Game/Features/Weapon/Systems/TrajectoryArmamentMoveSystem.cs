using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Components.Armaments;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class TrajectoryArmamentMoveSystem : SystemComponent<TrajectoryArmamentComponent>
  {
    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      Components.Foreach(Move);
    }
    
    private void Move(TrajectoryArmamentComponent throwableArmament) => 
      throwableArmament.transform.position = throwableArmament.transform.position.SetY(Height(throwableArmament));
    
    private float Height(TrajectoryArmamentComponent armament)
    {
      float percentDistance = (1 - CurrentDistance(armament) / armament.InitialSqrDistance);
      float curveHeight = armament.ThrowCurve.Evaluate(percentDistance) * armament.ThrowHeight;
      return armament.InitialHeight + curveHeight;
    }
    
    private float CurrentDistance(TrajectoryArmamentComponent armament) =>
      armament.transform.position.HorizontalProjectedSqrDistance(armament.TargetPosition);
  }

}
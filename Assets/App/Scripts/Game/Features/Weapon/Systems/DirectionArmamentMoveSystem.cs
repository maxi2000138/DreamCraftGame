using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class DirectionArmamentMoveSystem : SystemComponent<DirectionArmamentComponent>
  {
    protected override void OnUpdate()
    {
      Components.Foreach(Move);
    }
    
    private void Move(DirectionArmamentComponent armamentComponent) => armamentComponent.Armament.transform.position += armamentComponent.Direction * (armamentComponent.Armament.Speed * Time.deltaTime);
  }

}
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components.Armaments
{
  public class DirectionArmamentComponent : MonoComponent<DirectionArmamentComponent>
  {
    public ArmamentComponent Armament { get; private set; }
    public Vector3 Direction { get; private set; }

    public void Init(ArmamentComponent armament, Vector3 direction)
    {
      Armament = armament;
      Direction = direction;
    }
  }
}
using App.Scripts.Game.Features.Weapon.Variations;
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class WeaponComponent : MonoComponent<WeaponComponent>
  {
    public IWeapon Weapon { get; private set; }
    
    public void SetWeapon(IWeapon weapon) => Weapon = weapon;
  }
}
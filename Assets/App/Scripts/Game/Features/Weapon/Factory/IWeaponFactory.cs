using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Components.Armaments;
using App.Scripts.Game.Features.Weapon.Data;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Factory
{
  public interface IWeaponFactory
  {
    ArmamentComponent CreateArmament(WeaponType weaponType, Vector3 spawnPosition, Vector3 mousePosition);
    WeaponComponent CreateWeapon(WeaponType weaponType, Vector3 spawnPosition, Transform parent);
  }
}
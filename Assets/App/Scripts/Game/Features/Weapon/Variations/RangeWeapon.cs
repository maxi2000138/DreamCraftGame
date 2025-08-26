using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Data;
using App.Scripts.Game.Features.Weapon.Factory;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Variations
{
  public class RangeWeapon : BaseWeapon
  {
    private readonly WeaponType _weaponType;
    private readonly WeaponComponent _weapon;
    private readonly IWeaponFactory _weaponFactory;
    public RangeWeapon(WeaponComponent weapon, WeaponType weaponType, IWeaponFactory weaponFactory, WeaponCharacteristic weaponCharacteristic) : base(weaponCharacteristic)
    {
      _weapon = weapon;
      _weaponType = weaponType;
      _weaponFactory = weaponFactory;
    }

    public void Attack(Vector3 mousePosition)
    {
      Attack();
      _weaponFactory.CreateArmament(_weaponType, _weapon.SpawnPoint.position, mousePosition);
    }
  }
}
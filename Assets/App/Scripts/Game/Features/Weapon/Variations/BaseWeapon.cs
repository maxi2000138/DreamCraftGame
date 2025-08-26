using App.Scripts.Game.Features.Weapon.Data;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Variations
{
  public abstract class BaseWeapon : IWeapon
  {
    private readonly WeaponCharacteristic _weaponCharacteristic;

    private float _rechargeDelay;
    private bool _canAttack;

    bool IWeapon.CanAttack() => _canAttack;
    float IWeapon.AttackSqrRange() => _weaponCharacteristic.AttackSqrRange;

    protected BaseWeapon(WeaponCharacteristic weaponCharacteristic)
    {
      _weaponCharacteristic = weaponCharacteristic;
    }

    protected void Attack()
    {
      NotReadyAttack();
    }
    
    protected virtual int GetDamage() => _weaponCharacteristic.Damage;
    
    void IWeapon.Execute()
    {
      _rechargeDelay -= Time.deltaTime;
      
      if (_rechargeDelay <= 0f)
      {
        ReloadChargeDelay();
        ReadyAttack();
      }
    }

    private void ReloadChargeDelay() => _rechargeDelay = _weaponCharacteristic.RechargeTime;
    private void ReadyAttack() => _canAttack = true;
    private void NotReadyAttack() => _canAttack = false;
  }
}
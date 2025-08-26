using App.Scripts.Game.Features.Units.Shared.Interfaces;
using App.Scripts.Game.Features.Weapon.Data;

namespace App.Scripts.Game.Features.Weapon.Variations
{
  public class MeleeWeapon : BaseWeapon
  {
    public MeleeWeapon(WeaponCharacteristic weaponCharacteristic) : base(weaponCharacteristic)
    {
      
    }
    
    public void Attack(IUnit unit)
    {
      Attack();

      if (unit.Health.IsAlive)
      { 
        unit.Health.CurrentHealth.Value -= GetDamage();
      }
    }
  }

}
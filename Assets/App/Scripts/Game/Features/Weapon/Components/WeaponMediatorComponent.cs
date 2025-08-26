using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class WeaponMediatorComponent : MonoComponent<WeaponMediatorComponent>
  {
    [SerializeField] private Transform _container;
    public Transform Container => _container;
    public WeaponComponent CurrentWeapon { get; private set; }

    public void SetWeapon(WeaponComponent weapon)
    {
      if (CurrentWeapon != null)
      {
        CurrentWeapon.Remove();
      }

      CurrentWeapon = weapon;
    }

    public override void OnComponentDisable()
    {
      base.OnComponentDisable();
      CurrentWeapon = null;
    }
  }
}
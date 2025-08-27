using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Game.Features.Units.Character.Components;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Data;
using App.Scripts.Game.Features.Weapon.Factory;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using R3;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class ChangeWeaponSystem : SystemComponent<CharacterComponent>
  {
    private readonly IInputService _inputService;
    private readonly IWeaponFactory _weaponFactory;
    public ChangeWeaponSystem(IInputService inputService, IWeaponFactory weaponFactory)
    {
      _inputService = inputService;
      _weaponFactory = weaponFactory;
    }

    protected override void OnEnableComponent(CharacterComponent component)
    {
      base.OnEnableComponent(component);
      
      _inputService.SelectWeapon
        .Subscribe(index => ChangeWeapon(component, index))
        .AddTo(component.LifetimeDisposable);
    }

    private void ChangeWeapon(CharacterComponent component, int index)
    {
      WeaponComponent weaponComponent = null;   
      switch (index)
      {
        case 1:
           weaponComponent = _weaponFactory.CreateWeapon(WeaponType.Rifle, component.WeaponMediator.Container.position, 
             component.WeaponMediator.Container);
          break;
        case 2:
          weaponComponent = _weaponFactory.CreateWeapon(WeaponType.Bazooka, component.WeaponMediator.Container.position, 
            component.WeaponMediator.Container);
          break;
      }
      
      if(weaponComponent != null)
        component.WeaponMediator.SetWeapon(weaponComponent);
    }
  }
}
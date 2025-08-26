using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Weapon.Systems
{
  public class ExecuteWeaponSystem : SystemComponent<WeaponComponent>
  {
    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      Components.Foreach(ExecuteWeapon);
    }
    
    private void ExecuteWeapon(WeaponComponent weaponComponent)
    {
      if(weaponComponent.Weapon == null) return;
      
      weaponComponent.Weapon.Execute();
    }
  }
}
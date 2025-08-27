using App.Scripts.Game.Features.Units.Character._Configs;
using App.Scripts.Game.Features.Units.Character.Components;
using App.Scripts.Game.Features.Weapon.Data;
using App.Scripts.Game.Features.Weapon.Factory;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class CharacterInitializeSystem : SystemComponent<CharacterComponent>
  {
    private readonly IStaticDataService _staticData;
    private readonly ICameraService _cameraService;
    private readonly LevelModel _levelModel;
    private readonly IWeaponFactory _weaponFactory;

    public CharacterInitializeSystem(IStaticDataService staticData, ICameraService cameraService, LevelModel levelModel,
      IWeaponFactory weaponFactory)
    {
      _staticData = staticData;
      _cameraService = cameraService;
      _levelModel = levelModel;
      _weaponFactory = weaponFactory;
    }
    
    protected override void OnEnableComponent(CharacterComponent component)
    {
      base.OnEnableComponent(component);
      
      InitializeCharacter(component);
    }
    
    private void InitializeCharacter(CharacterComponent component)
    {
      CharacterConfig characterConfig = _staticData.CharacterConfig();

      _levelModel.SetCharacter(component);
      _cameraService.SetTarget(component.transform);

      component.Health.SetMaxHealth(characterConfig.Health);
      component.Health.CurrentHealth.SetValueAndForceNotify(characterConfig.Health);
      component.CharacterController.SetSpeed(characterConfig.Speed);
      
      component.WeaponMediator
        .SetWeapon(_weaponFactory
          .CreateWeapon(characterConfig.StartWeapon, component.WeaponMediator.Container.position, component.WeaponMediator.Container));
    }
  }
}
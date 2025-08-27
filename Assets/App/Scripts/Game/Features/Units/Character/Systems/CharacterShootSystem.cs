using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Game.Features.Units.Character.Components;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Variations;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class CharacterShootSystem : SystemComponent<CharacterComponent>
  {
    private readonly IInputService _inputService;
    private readonly LevelModel _levelModel;
    public CharacterShootSystem(IInputService inputService, LevelModel levelModel)
    {
      _inputService = inputService;
      _levelModel = levelModel;
    }
    
    protected override void OnEnableComponent(CharacterComponent component)
    {
      base.OnEnableComponent(component);

      _levelModel.StartGame.Subscribe(_ =>
      {
        _inputService.OnClick
          .Subscribe(position => Shoot(component, position))
          .AddTo(component.LifetimeDisposable);
      });
      
      _levelModel.EndGame.Subscribe(_ => component.LifetimeDisposable.Clear());
    }

    
    private void Shoot(CharacterComponent component, Vector3 position)
    {
      IWeapon weapon = component.WeaponMediator.CurrentWeapon.Weapon;
      if (weapon is RangeWeapon rangeWeapon)
      {
        rangeWeapon.Attack(StraightPositionToTarget(component.WeaponMediator.CurrentWeapon, position));
      }
    }
    
    private Vector3 StraightPositionToTarget(WeaponComponent weapon, Vector3 position) => position.SetY(weapon.transform.position.y);
  }
}
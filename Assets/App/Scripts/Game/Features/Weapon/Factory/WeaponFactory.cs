using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Features.Weapon.Data;
using App.Scripts.Game.Features.Weapon.Variations;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using Unit = R3.Unit;

namespace App.Scripts.Game.Features.Weapon.Factory
{
  public class WeaponFactory : IWeaponFactory
  {
    private readonly IStaticDataService _staticData;
    private readonly IObjectPoolService _pool;
    
    public WeaponFactory(IStaticDataService staticData, IObjectPoolService pool)
    {
      _staticData = staticData;
      _pool = pool;
    }
    
    public WeaponComponent CreateWeapon(WeaponType weaponType, Vector3 spawnPosition, Transform parent)
    {
      WeaponCharacteristic weaponCharacteristic = _staticData.WeaponsConfig().Weapons[weaponType];
      var weaponComponent = _pool.SpawnObject(weaponCharacteristic.WeaponPrefab, spawnPosition, Quaternion.identity, parent)
        .GetComponent<WeaponComponent>();

      switch(weaponType)
      {
        case WeaponType.Knife:
          weaponComponent.SetWeapon(new MeleeWeapon(weaponCharacteristic));
          break;
        default:
          weaponComponent.SetWeapon(new RangeWeapon(weaponComponent, weaponType, this, weaponCharacteristic));
          break;
      }

      return weaponComponent;
    }
    
    public ArmamentComponent CreateArmament(WeaponType weaponType, Vector3 spawnPosition, Vector3 mousePosition)
    {
      WeaponCharacteristic weaponCharacteristic = _staticData.WeaponsConfig().Weapons[weaponType];
      
      switch (weaponType)
      {
        case WeaponType.Rifle:
          return CreateRifleArmament(weaponCharacteristic, spawnPosition, mousePosition);
        case WeaponType.Bazooka:
          return CreateBazookaArmament(weaponCharacteristic, spawnPosition, mousePosition);
      }
      
      throw new System.NotImplementedException();
    }
    
    private ArmamentComponent CreateRifleArmament(WeaponCharacteristic weaponCharacteristic, Vector3 spawnPosition, Vector3 mousePosition)
    {
      Vector3 direction = (mousePosition - spawnPosition).normalized;

      ArmamentComponent armament = _pool.SpawnObject(weaponCharacteristic.ArmamentPrefab, spawnPosition, Quaternion.identity, null)
        .GetComponent<ArmamentComponent>();
      
      armament.SetDamage(weaponCharacteristic.Damage);
      armament.SetSpeed(weaponCharacteristic.Speed);
      armament.SetLifetime(weaponCharacteristic.Lifetime);
      
      armament.GetComponent<DirectionArmamentComponent>().Init(armament, direction);
      armament.GetComponent<CollisionArmament>().Init(armament, weaponCharacteristic.CollisionSqrDistance);
      
      armament.Spawned.OnNext(Unit.Default);
      return armament;
    }
    
    private ArmamentComponent CreateBazookaArmament(WeaponCharacteristic weaponCharacteristic, Vector3 spawnPosition, Vector3 mousePosition)
    {
      Vector3 direction = (mousePosition - spawnPosition).normalized;
      Vector3 targetPosition = mousePosition.SetY(spawnPosition.y);

      ArmamentComponent armament = _pool.SpawnObject(weaponCharacteristic.ArmamentPrefab, spawnPosition, Quaternion.identity, null)
        .GetComponent<ArmamentComponent>();
      
      armament.SetDamage(weaponCharacteristic.Damage);
      armament.SetSpeed(weaponCharacteristic.Speed);
      armament.SetLifetime(weaponCharacteristic.Lifetime);
      
      float initialSqrDistance = armament.transform.position.HorizontalProjectedSqrDistance(targetPosition);
      armament.GetComponent<TrajectoryArmamentComponent>()
        .Init(armament, targetPosition, weaponCharacteristic.ThrowHeight, weaponCharacteristic.ThrowCurve, initialSqrDistance, spawnPosition.y);
      armament.GetComponent<TargetExplosionArmamentComponent>()
        .Init(armament, Mathf.Pow(weaponCharacteristic.ExplosionRadius,2), targetPosition);
      armament.GetComponent<DirectionArmamentComponent>().Init(armament, direction);
      
      armament.Spawned.OnNext(Unit.Default);
      return armament;
    }
  }
}
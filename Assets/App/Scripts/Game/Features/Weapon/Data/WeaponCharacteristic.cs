using System;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Infrastructure.Pool.Item;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Game.Features.Weapon.Data
{
  [Serializable]
  public class WeaponCharacteristic
  {
    public WeaponComponent WeaponPrefab;
    public ArmamentComponent ArmamentPrefab;
    [Range(1,100)]  public int Damage;
    [Range(0f,10f)] public float Speed;
    [Range(0f,10f)] public float RechargeTime;
    [Range(0f,10f)] public float CollisionSqrDistance;
    [Range(0f,10f)] public float ExplosionRadius;
    [Range(0f,50f)] public float AttackSqrRange;
  }
}
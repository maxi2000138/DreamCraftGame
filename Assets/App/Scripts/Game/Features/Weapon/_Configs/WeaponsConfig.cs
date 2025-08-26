using System.Collections.Generic;
using App.Scripts.Game.Features.Weapon.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon._Configs
{
  [CreateAssetMenu(fileName = nameof(WeaponsConfig), menuName = "Configs/" + nameof(WeaponsConfig))]
  public class WeaponsConfig : SerializedScriptableObject
  {
    public Dictionary<WeaponType, WeaponCharacteristic> Weapons;
  }
}
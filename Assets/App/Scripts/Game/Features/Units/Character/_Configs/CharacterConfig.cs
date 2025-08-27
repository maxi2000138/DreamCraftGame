using App.Scripts.Game.Features.Weapon.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Character._Configs
{
  [CreateAssetMenu(fileName = nameof(CharacterConfig), menuName = "Configs/" + nameof(CharacterConfig))]
  public class CharacterConfig : SerializedScriptableObject
  {
    public WeaponType StartWeapon;
    [Range(0, 100)] public int Health;
    [Range(0, 10)] public float Speed;
  }
}
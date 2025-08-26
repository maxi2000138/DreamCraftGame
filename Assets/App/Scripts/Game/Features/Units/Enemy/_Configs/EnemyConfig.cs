using System.Collections.Generic;
using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy._Configs
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/" + nameof(EnemyConfig))]
  public class EnemyConfig : SerializedScriptableObject
  {
    public Dictionary<EnemyType, EnemyData> Enemies;
  }
  
  public class EnemyData
  {
    public EnemyComponent Prefab;
    [Range(1f, 10f)] public float Speed;
    [Range(10, 100)] public int Health;
  }
}
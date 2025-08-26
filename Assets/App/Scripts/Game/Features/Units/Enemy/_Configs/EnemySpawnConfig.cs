using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy._Configs
{
  [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "Configs/" + nameof(EnemySpawnConfig))]
  public class EnemySpawnConfig : SerializedScriptableObject
  {
    [Range(0, 10)] public float SpawnDelay;
    [Range(0, 10)] public float SpawnMargin;
  }
}
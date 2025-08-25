using App.Scripts.Game.Features.Units.Enemy.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI._Configs
{
  [CreateAssetMenu(fileName = nameof(UiConfig), menuName = "Configs/" + nameof(UiConfig))]
  public class UiConfig : SerializedScriptableObject
  {
    public EnemyHealthViewComponent EnemyHealthView;
  }
}
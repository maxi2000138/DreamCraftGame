using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Game.Infrastructure.Systems.Components;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Features.Units.Enemy.Components
{
  public class EnemyHealthViewComponent : MonoComponent<EnemyHealthViewComponent>
  {
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _canvasGroup;

    public Image Fill => _fill;
    public TextMeshProUGUI Text => _text;
    public CanvasGroup CanvasGroup => _canvasGroup;
    public ReactiveProperty<IEnemy> Enemy { get; } = new();
  }
}
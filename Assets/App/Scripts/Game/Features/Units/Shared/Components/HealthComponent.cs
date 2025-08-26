using App.Scripts.Game.Infrastructure.Systems.Components;
using App.Scripts.Utils.Constants;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Shared.Components
{
  public class HealthComponent : MonoComponent<HealthComponent>
  {
    public int MaxHealth { get; private set; }
    public bool IsAlive => CurrentHealth.Value > 0;
    public ReactiveProperty<int> CurrentHealth { get; } = new();

    public void SetMaxHealth(int maxHealth) => MaxHealth = maxHealth;
        
    public override string ToString() => string
      .Format(FormatText.Health, Mathf.Clamp(CurrentHealth.Value, 0, MaxHealth).ToString(), MaxHealth.ToString());
  }
}
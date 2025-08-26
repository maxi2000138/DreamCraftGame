using App.Scripts.Game.Features.Units.Character.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils;
using DG.Tweening;
using R3;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class CharacterHealthViewUpdateSystem : SystemComponent<CharacterHealthViewComponent>
  {
    private readonly LevelModel _levelModel;

    public CharacterHealthViewUpdateSystem(LevelModel levelModel)
    {
      _levelModel = levelModel;
    }

    protected override void OnEnableComponent(CharacterHealthViewComponent component)
    {
      base.OnEnableComponent(component);

      void SetHealth(int health)
      {
        component.Tween?.Kill();
        component.Text.text = _levelModel.Character.Health.ToString();

        float fillAmount = Mathematics.Remap(0, _levelModel.Character.Health.MaxHealth, 0, 1, health);
                    
        component.Fill.fillAmount = fillAmount;
        component.Tween = component.FillLerp.DOFillAmount(fillAmount, 0.25f).SetEase(Ease.Linear);
      }

      _levelModel.Character.Health.CurrentHealth
        .Subscribe(SetHealth)
        .AddTo(component.LifetimeDisposable);
    }

    protected override void OnDisableComponent(CharacterHealthViewComponent component)
    {
      base.OnDisableComponent(component);
            
      component.Tween?.Kill();
    }
  }
}
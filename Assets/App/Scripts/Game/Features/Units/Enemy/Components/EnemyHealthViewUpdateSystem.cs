using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy.Components
{
  public class EnemyHealthViewUpdateSystem : SystemComponent<EnemyHealthViewComponent>
  {
    private ICameraService _cameraService;
    public EnemyHealthViewUpdateSystem(ICameraService cameraService)
    {
      _cameraService = cameraService;
    }

    protected override void OnLateUpdate()
    {
      base.OnLateUpdate();

      Components.Foreach(UpdatePosition);
    }

    protected override void OnEnableComponent(EnemyHealthViewComponent component)
    {
      base.OnEnableComponent(component);

      component.Enemy
        .First(enemy => enemy != null)
        .Subscribe(enemy => SubscribeOnChangeHealth(component, enemy))
        .AddTo(component.LifetimeDisposable);
    }

    private void SubscribeOnChangeHealth(EnemyHealthViewComponent component, IEnemy enemy)
    {
      enemy.Health.CurrentHealth
        .Subscribe(health => {
          var fillAmount = Mathematics.Remap(0, enemy.Health.MaxHealth, 0, 1, health);

          component.Text.text = enemy.Health.ToString();
          component.Fill.fillAmount = fillAmount;
        })
        .AddTo(component.LifetimeDisposable);
    }

    private void UpdatePosition(EnemyHealthViewComponent component)
    {
      if (component.Enemy.Value.Health.IsAlive == false 
          || component.Enemy.Value.Health.CurrentHealth.Value == component.Enemy.Value.Health.MaxHealth)
      {
        component.CanvasGroup.alpha = 0f;

        return;
      }

      var height = component.Enemy.Value.Height;
      var position = component.Enemy.Value.Position.AddY(height);
      var screenPoint = _cameraService.Camera.WorldToScreenPoint(position);
      var viewportPoint = _cameraService.Camera.WorldToViewportPoint(position);
      component.transform.position = screenPoint.ZeroZ();
      component.CanvasGroup.alpha += _cameraService.IsOnScreen(viewportPoint)
        ? Time.deltaTime * 1f : Time.deltaTime * -1f;
    }
  }
}
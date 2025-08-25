using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Infrastructure.GUI.Screens;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Factory
{
    public interface IUIFactory
    {
        BaseScreen CreateScreen(ScreenType type);
        EnemyHealthViewComponent CreateEnemyHealth(IEnemy enemy, Transform parent);
    }
}
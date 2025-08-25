using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Infrastructure.GUI._Configs;
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Infrastructure.GUI.Service;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Utils.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Factory
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IGuiService _guiService;
        private readonly IObjectPoolService _poolService;

        public UIFactory(IStaticDataService staticData, IGuiService guiService, IObjectPoolService poolService)
        {
            _staticData = staticData;
            _guiService = guiService;
            _poolService = poolService;
        }

        BaseScreen IUIFactory.CreateScreen(ScreenType type)
        {
            _guiService.Pop();
            GameObject prefab = _staticData.ScreensConfig().Screens[type];
            BaseScreen screen = Object.Instantiate(prefab, _guiService.StaticCanvas.transform).GetComponent<BaseScreen>();
            _guiService.PushScreen(screen);
            return screen;
        }
        
        EnemyHealthViewComponent IUIFactory.CreateEnemyHealth(IEnemy enemy, Transform parent)
        {
            UiConfig config = _staticData.UiConfig();
            EnemyHealthViewComponent enemyHealth = _poolService
                .SpawnObject(config.EnemyHealthView, parent.position, Quaternion.identity, parent)
                .GetComponent<EnemyHealthViewComponent>();
            
            enemyHealth.Enemy.SetValueAndForceNotify(enemy);
            return enemyHealth;
        }
    }
}
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Infrastructure.GUI.Service;
using App.Scripts.Infrastructure.StaticData;
using JetBrains.Annotations;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Factory
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IGuiService _guiService;
        

        public UIFactory(IStaticDataService staticData, IGuiService guiService)
        {
            _staticData = staticData;
            _guiService = guiService;
        }

        BaseScreen IUIFactory.CreateScreen(ScreenType type)
        {
            _guiService.Pop();
            GameObject prefab = _staticData.ScreensConfig().Screens[type];
            BaseScreen screen = Object.Instantiate(prefab, _guiService.StaticCanvas.transform).GetComponent<BaseScreen>();
            _guiService.PushScreen(screen);
            return screen;
        }
    }
}
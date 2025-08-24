using App.Scripts.Infrastructure.GUI.Screens;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Factory
{
    public interface IUIFactory
    {
        BaseScreen CreateScreen(ScreenType type);
    }
}
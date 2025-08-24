using System.Collections.Generic;
using App.Scripts.Infrastructure.GUI.Screens;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI._Configs
{ 
    [CreateAssetMenu(fileName = nameof(ScreensConfig), menuName = "Configs/" + nameof(ScreensConfig))]
    public sealed class ScreensConfig : SerializedScriptableObject
    {
        public Dictionary<ScreenType, GameObject> Screens;
    }
}
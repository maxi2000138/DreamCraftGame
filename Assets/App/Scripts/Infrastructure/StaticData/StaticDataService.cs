using App.Scripts.Infrastructure.AssetData;
using App.Scripts.Infrastructure.GUI._Configs;
using App.Scripts.Infrastructure.Logger._Configs;
using UnityEngine;

namespace App.Scripts.Infrastructure.StaticData
{
    public sealed class StaticDataService : IStaticDataService
    {
        private const string DataFolder = "Configs/";
        
        private readonly IAssetService _assetService;

        private LoggerConfig _loggerConfig;
        private ScreensConfig _screensConfig;

        LoggerConfig IStaticDataService.LoggerConfig() => _loggerConfig ??= LoadConfig<LoggerConfig>();
        ScreensConfig IStaticDataService.ScreensConfig() => _screensConfig;
        
        public StaticDataService(IAssetService assetService)
        {
            _assetService = assetService;
        }

        void IStaticDataService.Load()
        {
            _loggerConfig ??= LoadConfig<LoggerConfig>();
        }
        
        private T LoadConfig<T>() where T : ScriptableObject => _assetService.LoadFromResources<T>(DataFolder + typeof(T).Name);
    }
}
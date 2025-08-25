using App.Scripts.Game.Features.Units.Character._Configs;
using App.Scripts.Game.Features.Units.Enemy._Configs;
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
        private CharacterConfig _characterConfig;
        private EnemyConfig _enemyConfig;
        private EnemySpawnConfig _enemySpawnConfig;
        private UiConfig _uiConfig;

        LoggerConfig IStaticDataService.LoggerConfig() => _loggerConfig ??= LoadConfig<LoggerConfig>();
        ScreensConfig IStaticDataService.ScreensConfig() => _screensConfig;
        CharacterConfig IStaticDataService.CharacterConfig() => _characterConfig;
        EnemyConfig IStaticDataService.EnemyConfig() => _enemyConfig;
        EnemySpawnConfig IStaticDataService.EnemySpawnConfig() => _enemySpawnConfig;
        UiConfig IStaticDataService.UiConfig() => _uiConfig;
        
        
        public StaticDataService(IAssetService assetService)
        {
            _assetService = assetService;
        }

        void IStaticDataService.Load()
        {
            _uiConfig ??= LoadConfig<UiConfig>();
            _enemyConfig ??= LoadConfig<EnemyConfig>();
            _loggerConfig ??= LoadConfig<LoggerConfig>();
            _screensConfig ??= LoadConfig<ScreensConfig>();
            _characterConfig ??= LoadConfig<CharacterConfig>();
            _enemySpawnConfig ??= LoadConfig<EnemySpawnConfig>();
        }
        
        private T LoadConfig<T>() where T : ScriptableObject => _assetService.LoadFromResources<T>(DataFolder + typeof(T).Name);
    }
}
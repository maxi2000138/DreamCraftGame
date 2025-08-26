using App.Scripts.Game.Features.Units.Character._Configs;
using App.Scripts.Game.Features.Units.Enemy._Configs;
using App.Scripts.Game.Features.Weapon._Configs;
using App.Scripts.Infrastructure.GUI._Configs;
using App.Scripts.Infrastructure.Logger._Configs;

namespace App.Scripts.Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        LoggerConfig LoggerConfig();
        ScreensConfig ScreensConfig();
        WeaponsConfig WeaponsConfig();
        CharacterConfig CharacterConfig();
        EnemySpawnConfig EnemySpawnConfig();
        EnemyConfig EnemyConfig();
        UiConfig UiConfig();
    }
}
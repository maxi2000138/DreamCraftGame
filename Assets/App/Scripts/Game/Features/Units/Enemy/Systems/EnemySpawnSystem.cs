  using System;
  using App.Scripts.Game.Features.Units.Enemy.Components;
  using App.Scripts.Game.Features.Units.Enemy.Data;
  using App.Scripts.Game.Infrastructure.Factory;
  using App.Scripts.Game.Infrastructure.Systems.Systems;
  using App.Scripts.Infrastructure.Camera;
  using App.Scripts.Infrastructure.StaticData;
  using App.Scripts.Utils.Extensions;
  using R3;
  using UnityEngine;
  using Random = UnityEngine.Random;

  namespace App.Scripts.Game.Features.Units.Enemy.Systems
  {
    public class EnemySpawnSystem : SystemBase
    {
      private const float HeightOffset = 0.1f;

      private readonly IStaticDataService _staticData;
      private readonly ICameraService _cameraService;
      private readonly IGameFactory _gameFactory;
      private readonly LevelModel _levelModel;

      private CameraRelativeBounds _cameraBounds;

      public EnemySpawnSystem(IStaticDataService staticData, ICameraService cameraService, IGameFactory gameFactory, LevelModel levelModel)
      {
        _staticData = staticData;
        _cameraService = cameraService;
        _gameFactory = gameFactory;
        _levelModel = levelModel;
      }

      protected override void OnEnableSystem()
      {
        base.OnEnableSystem();
        
        _levelModel.StartGame
          .Subscribe(_ =>
          {
            Observable.Interval(TimeSpan.FromSeconds(_staticData.EnemySpawnConfig().SpawnDelay))
              .Subscribe(__ => SpawnEnemy())
              .AddTo(LifetimeDisposable);
          })
          .AddTo(LifetimeDisposable);
      }

      private void SpawnEnemy()
      {
        if (_cameraBounds == null)
        {
          _cameraBounds = new CameraRelativeBounds();
          _cameraBounds.SetupRelativeBounds(_cameraService.Camera, _levelModel.Character.Position);
        }
          
        EnemyComponent enemy = _gameFactory.CreateEnemy(RandomEnemyType());

        Vector3 position = RandomSpawnPositionOutsideCamera().AddY(HeightOffset);
        TeleportEnemyTo(enemy, position);
      }

      private void TeleportEnemyTo(EnemyComponent enemy, Vector3 position)
      {
        enemy.CharacterController.CharacterController.enabled = false;
        enemy.transform.position = position;
        enemy.CharacterController.CharacterController.enabled = true;
      }
      
      private EnemyType RandomEnemyType()
      {
        EnemyType[] enemyTypes = (EnemyType[])Enum.GetValues(typeof(EnemyType));
        int randomIndex = Random.Range(0, enemyTypes.Length);
        return enemyTypes[randomIndex];
      }

      private Vector3 RandomSpawnPositionOutsideCamera()
      {
        var spawnMargin = _staticData.EnemySpawnConfig().SpawnMargin;
        var characterPosition = _levelModel.Character.Position;
        
        return (Random.Range(0, 4) switch
        {
          0 => _cameraBounds.RandomLeftBoundPosition(spawnMargin),
          1 => _cameraBounds.RandomRightBoundPosition(spawnMargin),
          2 => _cameraBounds.RandomDownBoundPosition(spawnMargin),
          _ => _cameraBounds.RandomUpBoundPosition(spawnMargin)
        }) + characterPosition;       
      }
    }
  }
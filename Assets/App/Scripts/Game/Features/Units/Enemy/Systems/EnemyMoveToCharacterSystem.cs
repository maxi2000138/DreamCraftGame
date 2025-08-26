using System.Threading.Tasks;
using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy.Systems
{
  public class EnemyMoveToCharacterSystem : SystemComponent<EnemyComponent>
  {
    private const float MinSqrDistance = 1f;

    private readonly LevelModel _levelModel;
    private readonly IUnitMover _unitMover;

    private Vector3 _direction;
    private Vector3 _distance;

    public EnemyMoveToCharacterSystem(LevelModel levelModel, IUnitMover unitMover)
    {
      _levelModel = levelModel;
      _unitMover = unitMover;
    }
    
    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      if(_levelModel.Character == null) return;
      
      Components.Foreach(MoveToCharacter);
    }
    
    private void MoveToCharacter(EnemyComponent enemy)
    {
      _distance = _levelModel.Character.Position - enemy.Position;

      if (_distance.sqrMagnitude > MinSqrDistance)
      { 
        _direction = _distance.normalized;
        _unitMover.Move(enemy, new Vector2(_direction.x, _direction.z));
      }
      
      _unitMover.UseGravity(enemy);
    }
  }
}
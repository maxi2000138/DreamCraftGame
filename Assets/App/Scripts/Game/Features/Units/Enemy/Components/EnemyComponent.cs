using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Game.Features.Units.Shared.Data.Components;
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy.Components
{
  public class EnemyComponent : MonoComponent<EnemyComponent>, IEnemy
  {
    [SerializeField] private CharacterControllerComponent _characterController;
    
    public CharacterControllerComponent CharacterController => _characterController;
    
    public Vector3 Position => transform.position;
  }
}
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using App.Scripts.Game.Features.Units.Shared.Components;
using App.Scripts.Game.Features.Weapon.Components;
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy.Components
{
  public class EnemyComponent : MonoComponent<EnemyComponent>, IEnemy
  {
    [SerializeField] private CharacterControllerComponent _characterController;
    [SerializeField] private HealthComponent _health;
    [SerializeField] private WeaponMediatorComponent _weaponMediator;
    
    public CharacterControllerComponent CharacterController => _characterController;
    public WeaponMediatorComponent WeaponMediator => _weaponMediator;
    public HealthComponent Health => _health;
    
    public Vector3 Position => transform.position;
    public float Height => 1f;
  }
}
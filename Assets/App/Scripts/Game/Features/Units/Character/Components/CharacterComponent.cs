using App.Scripts.Game.Features.Units.Character;
using App.Scripts.Game.Features.Units.Shared.Data.Components;
using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Character.Components
{
  public class CharacterComponent : MonoComponent<CharacterComponent>, ICharacter
  { 
    [SerializeField] private CharacterControllerComponent _characterController;
    [SerializeField] private HealthComponent _health;
    
    public CharacterControllerComponent CharacterController => _characterController;
    public HealthComponent Health => _health;
    
    public Vector3 Position => transform.position;
  }
}
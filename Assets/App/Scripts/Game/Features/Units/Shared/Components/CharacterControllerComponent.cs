using App.Scripts.Game.Infrastructure.Systems.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Shared.Components
{
  public class CharacterControllerComponent : MonoComponent<CharacterControllerComponent>
  {
    [SerializeField] private CharacterController _characterController;
        
    public CharacterController CharacterController => _characterController;
    public float Angle => transform.eulerAngles.y;
    public float Speed { get; private set; }
    public bool IsGrounded => _characterController.isGrounded;

    public void SetSpeed(float speed) => Speed = speed;
  }
}
using App.Scripts.Game.Features.Units.Shared.Interfaces;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Utils.Constants;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Shared.Services
{
  public class UnitMover : IUnitMover
  {
    private const float RayDistance = 5f;
    private const float LerpRotate = 0.25f;

    private readonly ICameraService _cameraService;
    
    public UnitMover(ICameraService cameraService)
    {
      _cameraService = cameraService;
    }
    
    void IUnitMover.Move(IUnit unit, Vector2 direction)
    {
      float angle = MoveAngles(direction); 

      Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
      Vector3 nextPosition = unit.Position + moveDirection * unit.CharacterController.Speed * Time.deltaTime;

      Ray ray = new Ray { origin = nextPosition, direction = Vector3.down };
      if (!Physics.Raycast(ray, RayDistance, Layers.Ground))
      {
        Debug.DrawLine(nextPosition, nextPosition + Vector3.down * RayDistance, Color.red);
        return;
      }
                
      moveDirection.y = unit.CharacterController.IsGrounded ? 0f : Physics.gravity.y;

      unit.CharacterController.CharacterController.Move(moveDirection * unit.CharacterController.Speed * Time.deltaTime);
    }

    void IUnitMover.Rotate(IUnit unit)
    {
      float lerpAngle = Mathf.LerpAngle(unit.CharacterController.Angle, MoveAngles(unit.CharacterController.CharacterController), LerpRotate);
      unit.CharacterController.transform.rotation = Quaternion.Euler(0f, lerpAngle, 0f);
    }

    void IUnitMover.UseGravity(IUnit unit)
    {
      if (unit.CharacterController.IsGrounded) return;
            
      Vector3 move = Vector3.zero;
      move.y = Physics.gravity.y;
      unit.CharacterController.CharacterController.Move(move * unit.CharacterController.Speed * Time.deltaTime);
    }
    
    private float MoveAngles(CharacterController characterController) => 
      MoveAngles(new Vector2(characterController.velocity.x, characterController.velocity.z));
    
    
    private float MoveAngles(Vector2 direction) => Mathf.Atan2(direction.x, direction.y) * 
      Mathf.Rad2Deg + _cameraService.Camera.transform.eulerAngles.y;
  }
}
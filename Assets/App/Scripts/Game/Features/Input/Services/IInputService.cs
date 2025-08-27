using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Input.Services
{
  public interface IInputService
  { 
    void Init();
    void Update();
    Vector2 GetAxis();
    Observable<Vector3> OnClick { get; }
    Observable<int> SelectWeapon { get; }
    float DeadZoneSqrSqrRadius { get; }
  }
}
using App.Scripts.Game.Features.Units.Shared.Data;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Shared.Services
{
  public interface IUnitMover
  {
    void Move(IUnit unit, Vector2 direction);
    void Rotate(IUnit unit);
    void UseGravity(IUnit unit);
  }
}
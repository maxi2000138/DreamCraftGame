using System.Collections.Generic;
using App.Scripts.Game.Features.Units.Character.Interfaces;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Collision
{
  public interface ICollisionService
  {
    bool EnemyCollision(Vector3 armamentPosition, float collisionSqrDistance, out List<IEnemy> collisions);
    bool CharacterCollision(Vector3 armamentPosition, float collisionSqrDistance, out ICharacter collision);
  }
}
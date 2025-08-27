using System.Collections.Generic;
using App.Scripts.Game.Features.Units.Character.Interfaces;
using App.Scripts.Game.Features.Units.Enemy.Interfaces;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Collision
{
  public class CollisionService : ICollisionService
  {
    private readonly LevelModel _levelModel;
    
    public CollisionService(LevelModel levelModel)
    {
      _levelModel = levelModel;
    }
    
    public bool EnemyCollision(Vector3 armamentPosition, float collisionSqrDistance, out List<IEnemy> collisions)
    {
      collisions = null;
      for (int i = 0; i < _levelModel.Enemies.Count; i++)
      {
        bool targetIsAlive = _levelModel.Enemies[i].Health.IsAlive;
        bool isCollision = (armamentPosition - _levelModel.Enemies[i].Position).sqrMagnitude < collisionSqrDistance;

        if (targetIsAlive && isCollision)
        {
          collisions ??= new List<IEnemy>();
          collisions.Add(_levelModel.Enemies[i]);
        }
      }
      
      return collisions != null;
    }

    public bool CharacterCollision(Vector3 armamentPosition, float collisionSqrDistance, out ICharacter collision)
    {
      bool targetIsAlive = _levelModel.Character.Health.IsAlive;
      bool isCollision = (armamentPosition - _levelModel.Character.Position).sqrMagnitude < collisionSqrDistance;

      if (targetIsAlive && isCollision)
      {
        collision = _levelModel.Character;
        return true;
      }
      
      collision = null;
      return false;
    }
  }
}
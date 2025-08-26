using App.Scripts.Game.Infrastructure.Systems.Components;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components
{
  public class ArmamentComponent : MonoComponent
  {
    public Vector3 Position => transform.position;
    
    public int Damage { get; private set; }
    public float Speed { get; private set; }

    public void SetSpeed(float speed) => Speed = speed;
    public void SetDamage(int damage) => Damage = damage;
    
  }
}
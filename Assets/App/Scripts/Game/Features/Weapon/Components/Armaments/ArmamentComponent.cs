using App.Scripts.Game.Infrastructure.Systems.Components;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Features.Weapon.Components.Armaments
{
  public class ArmamentComponent : MonoComponent<ArmamentComponent>
  {
    public Vector3 Position => transform.position;
    
    public int Damage { get; private set; }
    public float Speed { get; private set; }
    public float Lifetime { get; private set; }

    public Subject<Unit> Spawned = new Subject<Unit>();

    public void SetSpeed(float speed) => Speed = speed;
    public void SetDamage(int damage) => Damage = damage;
    public void SetLifetime(float lifetime) => Lifetime = lifetime;
    
  }
}
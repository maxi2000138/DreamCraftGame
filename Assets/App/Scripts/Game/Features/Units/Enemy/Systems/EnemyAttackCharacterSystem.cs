using App.Scripts.Game.Features.Units.Enemy.Components;
using App.Scripts.Game.Features.Weapon.Variations;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Units.Enemy.Systems
{
  public class EnemyAttackCharacterSystem : SystemComponent<EnemyComponent>
  {
    private readonly LevelModel _levelModel;
    public EnemyAttackCharacterSystem(LevelModel levelModel)
    {
      _levelModel = levelModel;
    }
    
    protected override void OnUpdate()
    {
      base.OnUpdate();
      Components.Foreach(TryAttackCharacter);
    }
    
    private void TryAttackCharacter(EnemyComponent enemy)
    {
      if(enemy.WeaponMediator.CurrentWeapon == null) return;
      
      IWeapon weapon = enemy.WeaponMediator.CurrentWeapon.Weapon;
      if ((_levelModel.Character.Position - enemy.Position).sqrMagnitude > weapon.AttackSqrRange()) return;

      if (weapon is MeleeWeapon meleeWeapon && weapon.CanAttack() && _levelModel.Character.Health.IsAlive)
      { 
        meleeWeapon.Attack(_levelModel.Character);
      }
    }
  }
}
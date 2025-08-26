namespace App.Scripts.Game.Features.Weapon.Variations
{
  public interface IWeapon
  {
    bool CanAttack();
    void Execute();
    float AttackSqrRange();
  }
}
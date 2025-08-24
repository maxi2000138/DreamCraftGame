namespace App.Scripts.Game.Infrastructure.Systems.Systems.Factory
{
  public interface ISystemFactory
  {
    ISystem Create<T>() where T : class, ISystem;
  }
}
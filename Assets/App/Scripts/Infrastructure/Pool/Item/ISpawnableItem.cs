namespace App.Scripts.Infrastructure.Pool.Item
{
  public interface ISpawnableItem
  {
    void OnCreated(IObjectPoolService objectPool);
    void OnSpawned();
    void OnDespawned();
    void OnRemoved();
  }

}
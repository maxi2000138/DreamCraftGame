using App.Scripts.Infrastructure.Pool.Item;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.Pool
{
    public interface IObjectPoolService
    {
        UniTask Init();
        MonoSpawnableItem SpawnObject(MonoSpawnableItem prefab);
        MonoSpawnableItem SpawnObject(MonoSpawnableItem prefab, Vector3 position, Quaternion rotation, Transform parent);
        void ReleaseObject(MonoSpawnableItem clone);
        void ReleaseAll();
        void DestroyAll();
    }
}
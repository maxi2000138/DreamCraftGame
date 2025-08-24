using App.Scripts.Infrastructure.UniqueId;
using UnityEngine;

namespace App.Scripts.Infrastructure.Pool.Factory
{
  public static class UnityObjectFactory
  {
    public static T Instantiate<T>(T prefab) where T : Object
    {
      var instance = UnityEngine.Object.Instantiate(prefab);
      instance.name = UniqueName(prefab.name);
      
      return instance;
    }

    public static T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : Object
    {
      var instance = UnityEngine.Object.Instantiate(prefab, position, rotation, parent);
      instance.name = UniqueName(prefab.name);
      
      return instance;
    }

    private static string UniqueName(string name) => $"{name}_{GameUniqueId.GetNextID()}";
  }
}
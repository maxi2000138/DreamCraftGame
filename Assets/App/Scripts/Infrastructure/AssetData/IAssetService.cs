using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.AssetData
{
  public interface IAssetService
  {
    T LoadFromResources<T>(string path) where T : Object;
    UniTaskVoid CleanUp();
  }
}
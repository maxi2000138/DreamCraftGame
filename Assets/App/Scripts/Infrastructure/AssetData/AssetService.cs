using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.AssetData
{
    public sealed class AssetService : IAssetService
    {
        T IAssetService.LoadFromResources<T>(string path) => Resources.Load<T>(path);
        
        async UniTaskVoid IAssetService.CleanUp()
        {
            await Resources.UnloadUnusedAssets();
        }
    }
}
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure.SceneLoader
{
    public sealed class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask Load(string name)
        {
            await SceneManager.LoadSceneAsync(name).ToUniTask();
        }
    }
}
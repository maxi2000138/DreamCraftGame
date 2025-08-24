using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure.SceneLoader
{
    public sealed class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask Load(string name)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
                return;
            
            await SceneManager.LoadSceneAsync(name).ToUniTask();
        }
    }
}
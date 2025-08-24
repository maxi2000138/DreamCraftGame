using Cysharp.Threading.Tasks;

namespace App.Scripts.Infrastructure.SceneLoader
{
    public interface ISceneLoaderService
    {
        UniTask Load(string name);
    }
}
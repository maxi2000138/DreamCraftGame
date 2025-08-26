using System.Collections.Generic;
using App.Scripts.Infrastructure.DI.Exception;
using App.Scripts.Infrastructure.DI.Scopes;
using UnityEngine.SceneManagement;
namespace App.Scripts.Infrastructure.DI.Registry
{
    public class SceneScopeRegistry : IScopeRegistry
    {
        private Dictionary<Scene, LifetimeScopeScene> _scopes = new Dictionary<Scene, LifetimeScopeScene>();
    
        public LifetimeScopeScene GetSceneScope(Scene scene)
        {
            if (_scopes.TryGetValue(scene, out var scope))
                return scope;
        
            throw new MyContainerException("Can't get scene scope because it doesn't exist in the registry");
        }
        public void Add(LifetimeScopeScene scope)
        {
            if (_scopes.ContainsKey(scope.gameObject.scene))
            {
                throw new MyContainerException("Can't add scene scope because it already exists in the registry");
            }
        
            _scopes.Add(scope.gameObject.scene, scope);
        }

        public void Remove(LifetimeScopeScene scope)
        {
            if (_scopes.Remove(scope.gameObject.scene) == false)
            {
                throw new MyContainerException("Can't remove scene scope because it doesn't exist in the registry");
            }
        }
        public void Dispose()
        {
            foreach (var scopeKey in _scopes.Keys)
            {
                if(_scopes.TryGetValue(scopeKey, out var scope) && scope != null)
                    scope.Dispose();
            }
        }
    }
}

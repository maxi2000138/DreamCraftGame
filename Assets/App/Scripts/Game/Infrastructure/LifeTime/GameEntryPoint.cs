using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Infrastructure.LifeTime;
using App.Scripts.Infrastructure.UniqueId;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.LifeTime
{
  public class GameEntryPoint : MonoBehaviour, IEntryPoint
  {
    private SystemsContainer _systemsContainer;

    public void Construct(SystemsContainer systemsContainer)
    {
      _systemsContainer = systemsContainer;
    }
    
    public void Entry()
    {
      InitGameServices();
      
      Initialize();
    }

    private void Initialize()
    {
      _systemsContainer.Initialize();
    }

    private void Update()
    {
      _systemsContainer.Tick();
    }

    private void LateUpdate()
    {
      _systemsContainer.LateTick();
    }

    private void FixedUpdate()
    {
      _systemsContainer.FixedTick();
    }

    private void OnDestroy()
    {
      _systemsContainer.Dispose();
    }
    
    private void InitGameServices()
    {
      GameUniqueId.Reset();
    }
  }
}

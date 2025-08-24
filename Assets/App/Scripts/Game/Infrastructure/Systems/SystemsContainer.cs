using System;

namespace App.Scripts.Game.Infrastructure.Systems
{
  public class SystemsContainer : IDisposable
  {
    private readonly Feature _feature;

    public SystemsContainer(Feature feature)
    {
      _feature = feature;
    }
    
    public void Initialize()
    {
      _feature.EnableSystems();
    }
    
    public void Tick()
    { 
      _feature.Update();
    }
    
    public void FixedTick()
    { 
      _feature.FixedUpdate();
    }
    
    public void LateTick()
    {
        _feature.LateUpdate();
    }

    public void Dispose()
    {
      _feature.DisableSystems();
      _feature.Dispose();
    }
  }
}
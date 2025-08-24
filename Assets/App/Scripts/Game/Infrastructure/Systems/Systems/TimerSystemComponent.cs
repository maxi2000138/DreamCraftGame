﻿using App.Scripts.Game.Infrastructure.Systems.Components;
using App.Scripts.Infrastructure.Time;

namespace App.Scripts.Game.Infrastructure.Systems.Systems
{
  public abstract class TimerSystemComponent<T> : SystemComponent<T> where T : IComponent
  {
    private ITimeService _time;
    private float _executeIntervalSeconds;
        
    private float _timeToExecute;

    protected void Initialize(float executeIntervalSeconds, ITimeService time)
    {
      _executeIntervalSeconds = executeIntervalSeconds;
      _time = time;

    }
    
    protected abstract void OnTimerUpdate();

    protected override void OnUpdate()
    {
      _timeToExecute -= _time.DeltaTime;
      if (_timeToExecute > 0)
        return;
      
      _timeToExecute = _executeIntervalSeconds - _timeToExecute;
      OnTimerUpdate();
    }
  }
}
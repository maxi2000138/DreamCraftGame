using App.Scripts.Game.Infrastructure.StateMachine;
using App.Scripts.Game.Infrastructure.StateMachine.States;
using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Infrastructure.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.LifeTime
{
  public class GameEntryPoint : MonoBehaviour, IEntryPoint
  {
    private SystemsContainer _systemsContainer;
    
    private IGameStateMachine _gameStateMachine;

    public void Construct(SystemsContainer systemsContainer, IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      _systemsContainer = systemsContainer;
    }
    
    public void Entry()
    {
      Initialize();
      _gameStateMachine.Enter<StateLobby>().Forget();
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
  }
}

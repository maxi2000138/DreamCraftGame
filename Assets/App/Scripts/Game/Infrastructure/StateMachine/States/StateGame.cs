using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces;
using App.Scripts.Infrastructure.GUI.Factory;
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;
using R3;

namespace App.Scripts.Game.Infrastructure.StateMachine.States
{
  public class StateGame : IEnterState, IExitState
  {
    private readonly IUIFactory _uiFactory;
    private readonly LevelModel _levelModel;
    private readonly IUnitMover _unitMover;
    private readonly CompositeDisposable _transitionDisposable = new();
    
    private IGameStateMachine _gameStateMachine;
    public StateGame(IUIFactory uiFactory, LevelModel levelModel, IUnitMover unitMover)
    {
      _uiFactory = uiFactory;
      _levelModel = levelModel;
      _unitMover = unitMover;
    }

    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      
      _uiFactory.CreateScreen(ScreenType.Game);
      _unitMover.Resume();

      _levelModel.StartGame.Execute(Unit.Default);
      
      SubscribeOnLoose();
      return UniTask.CompletedTask;
    }
    
    public UniTask Exit(IGameStateMachine gameStateMachine)
    {
      _transitionDisposable.Dispose();
      
      return UniTask.CompletedTask;
    }
    
    private void SubscribeOnLoose()
    {
      _levelModel.Character.Health.CurrentHealth
          .First(_ => CharacterIsDeath())
          .Subscribe(_ => Loose())
          .AddTo(_transitionDisposable);
    }
    
    private void Loose()
    {
      _levelModel.EndGame.Execute(Unit.Default);
      _gameStateMachine.Enter<StateGameEnd>();
    }
    
    private bool CharacterIsDeath() => _levelModel.Character.Health.IsAlive == false;
  }
}
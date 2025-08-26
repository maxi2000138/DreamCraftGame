using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces;
using App.Scripts.Infrastructure.Curtain;
using App.Scripts.Infrastructure.GUI.Factory;
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.StateMachine.States
{
  public class StateLobby : IEnterState
  {
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly IUnitMover _unitMover;
    private readonly IUIFactory _uiFactory;
    
    public StateLobby(ILoadingCurtain loadingCurtain, IUnitMover unitMover, IUIFactory uiFactory)
    {
      _loadingCurtain = loadingCurtain;
      _unitMover = unitMover;
      _uiFactory = uiFactory;
    }

    public async UniTask Enter(IGameStateMachine gameStateMachine)
    {
      _loadingCurtain.Hide();

      _unitMover.Stop();
      BaseScreen screen = _uiFactory.CreateScreen(ScreenType.Lobby);
      await screen.CloseScreen.ToUniTask();

      gameStateMachine.Enter<StateGame>().Forget();
    }
  }
}
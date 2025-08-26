using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces;
using App.Scripts.Infrastructure;
using App.Scripts.Infrastructure.Curtain;
using App.Scripts.Infrastructure.GUI.Factory;
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.SceneLoader;
using App.Scripts.Infrastructure.UniqueId;
using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.StateMachine.States
{
  public class StateGameEnd : IEnterState
  {
    private readonly IUIFactory _uiFactory;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly IObjectPoolService _objectPool;
    private readonly IUnitMover _unitMover;
    private readonly IObjectPoolService _poolService;
    
    public StateGameEnd(IUIFactory uiFactory, ISceneLoaderService sceneLoader, 
      ILoadingCurtain loadingCurtain, IObjectPoolService objectPool, IUnitMover unitMover) 
    {
      _uiFactory = uiFactory;
      _objectPool = objectPool;
      _unitMover = unitMover;
      _sceneLoader = sceneLoader;
      _loadingCurtain = loadingCurtain;
    }

    public async UniTask Enter(IGameStateMachine gameStateMachine)
    {
      _unitMover.Stop();
      BaseScreen screen = _uiFactory.CreateScreen(ScreenType.GameEnd);
      await screen.CloseScreen.ToUniTask();

      _loadingCurtain.Show();
      ResetAllServices();
      
      _sceneLoader.Load(Scenes.GAMEPLAY).Forget();
    }
    
    private void ResetAllServices()
    {
      _objectPool.ReleaseAll();
      GameUniqueId.Reset();
    }
  }
}
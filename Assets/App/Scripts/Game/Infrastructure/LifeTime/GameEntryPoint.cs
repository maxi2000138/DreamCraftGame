using App.Scripts.Game.Infrastructure.Systems;
using App.Scripts.Infrastructure.GUI.Factory;
using App.Scripts.Infrastructure.GUI.Screens;
using App.Scripts.Infrastructure.LifeTime;
using App.Scripts.Infrastructure.UniqueId;
using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using R3;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.LifeTime
{
  public class GameEntryPoint : MonoBehaviour, IEntryPoint
  {
    private SystemsContainer _systemsContainer;
    private IUIFactory _uiFactory;
    private LevelModel _levelModel;
    
    private CompositeDisposable _transitionDisposable = new();

    public void Construct(SystemsContainer systemsContainer, IUIFactory uiFactory, LevelModel levelModel)
    {
      _levelModel = levelModel;
      _uiFactory = uiFactory;
      _systemsContainer = systemsContainer;
    }
    
    public void Entry()
    {
      EntryGame().Forget();
    }
    
    private async UniTaskVoid EntryGame()
    {
      InitGameServices();
      Initialize();

      BaseScreen screen = _uiFactory.CreateScreen(ScreenType.Lobby);
      await screen.CloseScreen.ToUniTask();
      
      _uiFactory.CreateScreen(ScreenType.Game);
      _levelModel.StartGame.Execute(Unit.Default);
      
      
    }
    
    private void SubscribeOnLoose()
    {
      _levelModel.Character.Health.CurrentHealth
        .First(_ => CharacterIsDeath())
        .Subscribe(_ => Loose())
        .AddTo(_transitionDisposable);
    }
    
    private void InitGameServices()
    {
      GameUniqueId.Reset();
    }
    
    private bool CharacterIsDeath() => _levelModel.Character.Health.IsAlive == false;


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

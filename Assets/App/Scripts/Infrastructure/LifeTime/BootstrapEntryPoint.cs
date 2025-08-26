using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Infrastructure.Curtain;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Infrastructure.LifeTime
{
  public class BootstrapEntryPoint : IEntryPoint
  {
    private readonly IStaticDataService _staticData;
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly IObjectPoolService _poolService;
    private readonly IInputService _inputService;

    public BootstrapEntryPoint(IStaticDataService staticData, ILoadingCurtain loadingCurtain, IObjectPoolService poolService,
      IInputService inputService)
    {
      _staticData = staticData;
      _loadingCurtain = loadingCurtain;
      _poolService = poolService;
      _inputService = inputService;
    }
    
    public void Entry()
    {
      _loadingCurtain.Show();
      
      Application.targetFrameRate = 60; 
      QualitySettings.vSyncCount = 0;
      
      _staticData.Load();

      InitGlobalServices();
    }
    
    private void InitGlobalServices()
    {
      _poolService.Init();
      _inputService.Init();
    }
  }
}
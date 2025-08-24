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

    public BootstrapEntryPoint(IStaticDataService staticData, ILoadingCurtain loadingCurtain, IObjectPoolService poolService)
    {
      _staticData = staticData;
      _loadingCurtain = loadingCurtain;
      _poolService = poolService;
    }
    
    public void Entry()
    {
      _loadingCurtain.Show();
      
      Application.targetFrameRate = 60; 
      QualitySettings.vSyncCount = 0;
      
      _staticData.Load();

      InitGlobalServices();
      
      _loadingCurtain.Hide();
    }
    
    private void InitGlobalServices()
    {
      _poolService.Init();
    }
  }
}
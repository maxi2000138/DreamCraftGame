using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Infrastructure.AssetData;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.Curtain;
using App.Scripts.Infrastructure.GUI.Service;
using App.Scripts.Infrastructure.Logger;
using App.Scripts.Infrastructure.Pool;
using App.Scripts.Infrastructure.StaticData;
using MyContainer.Container;
using Scopes;
using UnityEngine;

namespace App.Scripts.Infrastructure.LifeTime
{
  public class BootstrapScope : LifetimeScopeProject
  {
    [SerializeField] private CameraService _cameraService;
    [SerializeField] private LoadingCurtain _loadingCurtain;
    [SerializeField] private GuiService _guiService;
    
    public override void Configure(IRegistrationContainer container)
    {
      container.Register<IRegistrationContainer>().FromInstance(container);
      
      container.Register<ILoadingCurtain>().FromInstance(_loadingCurtain);
      container.Register<ICameraService>().FromInstance(_cameraService);
      container.Register<IGuiService>().FromInstance(_guiService);
      
      container.Register<DebugLogger>();
      container.Register<IAssetService, AssetService>();
      container.Register<IInputService, PcInputService>();
      container.Register<IStaticDataService, StaticDataService>();
      container.Register<IObjectPoolService, ObjectPoolService>().WithArguments(transform);
      
      container.Register<BootstrapEntryPoint>();
    }

    protected override void AfterInitialize(IRegistrationContainer container)
    {
      base.AfterInitialize(container);
      
      InitNonLazyServices(container);
      ConstructMonoBehaviours(container);

      container.Resolve<BootstrapEntryPoint>().Entry();
    }
    
    private void InitNonLazyServices(IRegistrationContainer container)
    {
      container.Resolve<DebugLogger>();
    }

    private void ConstructMonoBehaviours(IRegistrationContainer container)
    {
      container.Resolve<IGuiService>().Construct(container.Resolve<ICameraService>());
    }
  }
}
using App.Scripts.Game.Features.Character.Components;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.StaticData;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class CharacterInitializeSystem : SystemComponent<CharacterComponent>
  {
    private readonly IStaticDataService _staticData;
    private readonly ICameraService _cameraService;

    public CharacterInitializeSystem(IStaticDataService staticData, ICameraService cameraService)
    {
      _staticData = staticData;
      _cameraService = cameraService;
    }
    
    protected override void OnEnableComponent(CharacterComponent component)
    {
      base.OnEnableComponent(component);
      
      InitializeCharacter(component);
    }
    
    private void InitializeCharacter(CharacterComponent component)
    {
      component.CharacterController.SetSpeed(_staticData.CharacterConfig().Speed);
      _cameraService.SetTarget(component.transform);
    }
  }
}
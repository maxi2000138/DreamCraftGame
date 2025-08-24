using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Game.Infrastructure.Systems.Systems;

namespace App.Scripts.Game.Features.Input.Systems
{
  public class InputUpdateSystem : SystemBase
  {
    private readonly IInputService _inputService;
    
    public InputUpdateSystem(IInputService inputService)
    {
      _inputService = inputService;
    }

    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      _inputService.Update();
    }
  }
}
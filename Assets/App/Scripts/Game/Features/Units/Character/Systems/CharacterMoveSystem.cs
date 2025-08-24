using App.Scripts.Game.Features.Character.Components;
using App.Scripts.Game.Features.Input.Services;
using App.Scripts.Game.Features.Units.Shared.Services;
using App.Scripts.Game.Infrastructure.Systems.Systems;
using App.Scripts.Utils.Extensions;

namespace App.Scripts.Game.Features.Units.Character.Systems
{
  public class CharacterMoveSystem : SystemComponent<CharacterComponent>
  {
    private readonly IInputService _inputService;
    private readonly IUnitMover _unitMover;
    
    public CharacterMoveSystem(IInputService inputService, IUnitMover unitMover)
    {
      _inputService = inputService;
      _unitMover = unitMover;
    }

    protected override void OnUpdate()
    {
      base.OnUpdate();
      
      Components.Foreach(MoveAndRotate);
      
    }
    
    private void MoveAndRotate(CharacterComponent component)
    {
      if(HasInput()) 
        _unitMover.Move(component, _inputService.GetAxis());
      
      _unitMover.Rotate(component);
      _unitMover.UseGravity(component);
    }
    
    private bool HasInput() => _inputService.GetAxis().sqrMagnitude > _inputService.DeadZoneSqrSqrRadius;
  }
}
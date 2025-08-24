using System.Collections.Generic;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.GUI.Canvas;
using App.Scripts.Infrastructure.GUI.Screens;
using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Service
{
  public sealed class GuiService : MonoBehaviour, IGuiService
  {
    [SerializeField] private StaticCanvas _staticCanvas;
        
    private ICameraService _cameraService;

    private readonly Stack<BaseScreen> _screens = new ();

    void IGuiService.Construct(ICameraService cameraService)
    {
      _cameraService = cameraService;
    }
        
    StaticCanvas IGuiService.StaticCanvas => _staticCanvas;
        
    void IGuiService.PushScreen(BaseScreen screen)
    {
      if (_screens.TryPeek(out BaseScreen oldScreen))
      {
        oldScreen.SetActive(false);
      }
            
      _cameraService.ActivateCamera(screen.GetScreenType());
            
      _screens.Push(screen);
    }
    
    void IGuiService.Pop()
    {
      if (_screens.TryPop(out BaseScreen oldScreen))
      {
        Destroy(oldScreen.gameObject);
      }
            
      if (_screens.TryPeek(out BaseScreen screen))
      {
        _cameraService.ActivateCamera(screen.GetScreenType());

        screen.SetActive(true);
      }
    }

    void IGuiService.Cleanup()
    {
      foreach (BaseScreen screen in _screens)
      {
        Destroy(screen.gameObject);
      }
            
      _screens.Clear();
    }
  }
}
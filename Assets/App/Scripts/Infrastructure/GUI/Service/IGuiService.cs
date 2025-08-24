using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.GUI.Canvas;
using App.Scripts.Infrastructure.GUI.Screens;

namespace App.Scripts.Infrastructure.GUI.Service
{
  public interface IGuiService
  {
    StaticCanvas StaticCanvas { get; }
    void PushScreen(BaseScreen screen);
    void Pop();
    void Cleanup();
    void Construct(ICameraService cameraService);
  }
}
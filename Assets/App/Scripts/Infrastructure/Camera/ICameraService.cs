using App.Scripts.Infrastructure.GUI.Screens;
using UnityEngine;

namespace App.Scripts.Infrastructure.Camera
{
  public interface ICameraService
  {
    UnityEngine.Camera Camera { get; }
    void SetTarget(Transform target);
    void Cleanup();
    bool IsOnScreen(Vector3 viewportPoint);
  }
}
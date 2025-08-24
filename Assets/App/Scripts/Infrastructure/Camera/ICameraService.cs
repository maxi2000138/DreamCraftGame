using App.Scripts.Infrastructure.GUI.Screens;
using UnityEngine;

namespace App.Scripts.Infrastructure.Camera
{
  public interface ICameraService
  {
    UnityEngine.Camera Camera { get; }
    void SetTarget(Transform target);
    void ActivateCamera(ScreenType type);
    Vector3 ScreenToWorldPoint(Vector3 screenPoint);
    void Cleanup();
  }
}
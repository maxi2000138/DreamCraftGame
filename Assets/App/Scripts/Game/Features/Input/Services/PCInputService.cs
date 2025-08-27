using App.Scripts.Infrastructure.Camera;
using App.Scripts.Utils.Constants;
using UnityEngine;
using R3;

namespace App.Scripts.Game.Features.Input.Services
{
  public class PcInputService : IInputService
  {
    private const float DeadZoneRadius = 0.1f;
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    
    private readonly ICameraService _cameraService;
    private readonly Subject<Vector3> _clickSubject = new Subject<Vector3>();
    
    private float _deadZoneSqrRadius;

    Observable<Vector3> IInputService.OnClick => _clickSubject;
    public float DeadZoneSqrSqrRadius => _deadZoneSqrRadius;

    public PcInputService(ICameraService cameraService)
    {
      _cameraService = cameraService;
    }
    
    public void Init()
    {
      _deadZoneSqrRadius = Mathf.Pow(DeadZoneRadius, 2);
    }

    Vector2 IInputService.GetAxis()
    {
      float horizontal = UnityEngine.Input.GetAxisRaw(HorizontalAxisName);
      float vertical = UnityEngine.Input.GetAxisRaw(VerticalAxisName);

      return new Vector2(horizontal, vertical).normalized;
    }

    void IInputService.Update()
    {
      if (UnityEngine.Input.GetMouseButtonDown(0))
      {
        Vector3 mousePos = UnityEngine.Input.mousePosition;
        Ray screenPointToRay = _cameraService.Camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(screenPointToRay, out RaycastHit hit, float.MaxValue, Layers.Ground))
        { 
          _clickSubject.OnNext(hit.point);
        }
      }
    }
  }
}
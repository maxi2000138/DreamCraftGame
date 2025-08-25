using App.Scripts.Utils.Constants;
using UnityEngine;

namespace App.Scripts.Game.Features.Units.Enemy.Data
{
  public class CameraRelativeBounds
  {
    private const float RaycastDistance = 500f;
    
    private Vector3 _leftDownPosition; 
    private Vector3 _rightDownPosition; 
    private Vector3 _rightUpPosition; 
    private Vector3 _leftUpPosition;

    public Vector3 RandomDownBoundPosition(float margin) => Vector3.Lerp(_leftDownPosition, _rightDownPosition, Random.Range(0f,1f)) + margin * Vector3.back;
    public Vector3 RandomRightBoundPosition(float margin) => Vector3.Lerp(_rightDownPosition, _rightUpPosition, Random.Range(0f,1f)) + margin * Vector3.right;
    public Vector3 RandomUpBoundPosition(float margin) => Vector3.Lerp(_rightUpPosition, _leftUpPosition, Random.Range(0f,1f)) + margin * Vector3.forward;
    public Vector3 RandomLeftBoundPosition(float margin) => Vector3.Lerp(_leftUpPosition, _leftDownPosition, Random.Range(0f,1f)) + margin * Vector3.left;

    public void SetupRelativeBounds(Camera camera, Vector3 relativePoint)
    {
      Ray leftDownRay = camera.ViewportPointToRay(new Vector3(0f, 0f, 0f));
      Ray rightDownRay = camera.ViewportPointToRay(new Vector3(1f, 0f, 0f));
      Ray rightUpRay = camera.ViewportPointToRay(new Vector3(1f, 1f, 0f));
      Ray leftUpRay = camera.ViewportPointToRay(new Vector3(0f, 1f, 0f));

      if (Physics.Raycast(leftDownRay, out RaycastHit hit, RaycastDistance, Layers.Ground)) 
        _leftDownPosition = hit.point - relativePoint;
        
      if(Physics.Raycast(rightDownRay, out hit, RaycastDistance, Layers.Ground)) 
        _rightDownPosition = hit.point - relativePoint;
        
      if(Physics.Raycast(rightUpRay, out hit, RaycastDistance, Layers.Ground)) 
        _rightUpPosition = hit.point - relativePoint;
        
      if(Physics.Raycast(leftUpRay, out hit, RaycastDistance, Layers.Ground)) 
        _leftUpPosition = hit.point - relativePoint;
    }
  }
}
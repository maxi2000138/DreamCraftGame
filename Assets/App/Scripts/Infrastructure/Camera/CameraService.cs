using App.Scripts.Infrastructure.GUI.Screens;
using Unity.Cinemachine;
using UnityEngine;

namespace App.Scripts.Infrastructure.Camera
{
    public sealed class CameraService : MonoBehaviour, ICameraService
    {
        [SerializeField] private UnityEngine.Camera _camera;
        [SerializeField] private CinemachineCamera _cameraZoomIn;
        [SerializeField] private CinemachineCamera _cameraZoomOut;

        UnityEngine.Camera ICameraService.Camera => _camera;

        void ICameraService.SetTarget(Transform target)
        {
            _cameraZoomIn.Follow = target;
            _cameraZoomIn.LookAt = target;
            _cameraZoomOut.Follow = target;
            _cameraZoomOut.LookAt = target;
        }
        
        bool ICameraService.IsOnScreen(Vector3 viewportPoint) => viewportPoint is { x: > 0f and < 1f, y: > 0f and < 1f };
        
        void ICameraService.Cleanup()
        {
            _cameraZoomIn.Follow = null;
            _cameraZoomIn.LookAt = null;
            _cameraZoomOut.Follow = null;
            _cameraZoomOut.LookAt = null;
        }
    }
}
using Cinemachine;
using UnityEngine;

public class CinemachineSwitcherFree : MonoBehaviour
{
    private CinemachineVirtualCamera _previousCamera;
    private CinemachineVirtualCamera _currentCamera;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        _previousCamera = _currentCamera; 
        _currentCamera = col.GetComponent<CinemachineVirtualCamera>();
        
        if (_currentCamera.Priority == 0)
        {
            _currentCamera.Priority = 1;
        }
        else if (_currentCamera.Priority == 1)
        { 
            if (_previousCamera == null) return;
            _previousCamera.Priority = 0;
        }
    }
}
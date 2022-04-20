using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcherArray : MonoBehaviour
{

    [SerializeField] private InputAction action;
   
    [SerializeField] private CinemachineVirtualCamera[] vcam;

    public int priority = 0;
    
    private void Start()
    {
        action.performed += _ => SwitchPriority();
    }

    private void SwitchPriority ()
    {
        priority++;
        priority = Mathf.Clamp(priority, 0, vcam.Length-1);
        vcam[priority].Priority += priority;
    }

    private void OnEnable() => action.Enable();
    private void OnDisable() => action.Disable();
}
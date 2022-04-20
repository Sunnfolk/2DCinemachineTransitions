using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcherArray : MonoBehaviour
{

    [SerializeField] private InputAction action;
    [SerializeField] private InputAction action2;
   
    [SerializeField] private CinemachineVirtualCamera[] vcam;

    public int priority = 0;
    
    private void Start()
    {
        action.performed += _ => SwitchPriority();
        action2.performed += _ => NegPri();
    }

    private void SwitchPriority ()
    {
        priority++;
        priority = Mathf.Clamp(priority, 0, vcam.Length-1);
        vcam[priority].Priority += priority;
    }
    private void NegPri ()
    {
        vcam[priority].Priority -= priority;
        priority--;
        priority = Mathf.Clamp(priority, 0, vcam.Length-1);
    }

    private void OnEnable()
    {
        action.Enable();
        action2.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
        action2.Disable();
    }
}
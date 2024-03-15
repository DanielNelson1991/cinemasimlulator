using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemaMachineManager : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera _PlayerCamera;
    [SerializeField]
    private CinemachineVirtualCamera _MonitorCamera;

    private bool _PlayerCameraSet = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchPriority()
    {
        
        if(_PlayerCameraSet)
        {
            _PlayerCamera.Priority = 0;
            _MonitorCamera.Priority = 1;
        } else
        {
            _MonitorCamera.Priority = 0;
            _PlayerCamera.Priority = 1;
        }

        Debug.Log("SwitchedCamera : " + _PlayerCameraSet);

        _PlayerCameraSet = !_PlayerCameraSet;    
    }
}

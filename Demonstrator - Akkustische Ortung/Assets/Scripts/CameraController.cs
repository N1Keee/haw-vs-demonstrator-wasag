using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook equipmentCamera;
    [SerializeField] private CinemachineFreeLook pileCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        equipmentCamera.Priority = 1;
        pileCamera.Priority = 0;
    }

    public void SwitchCamera()
    {
        equipmentCamera.Priority = (equipmentCamera.Priority + 1) % 2;
        pileCamera.Priority = (pileCamera.Priority + 1) % 2;
    }
}

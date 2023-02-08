using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook equipmentCamera;
    [SerializeField] private CinemachineFreeLook pileCamera;

    [SerializeField] private CinemachineVirtualCamera endCamera;
    
    // end screen
    [SerializeField] private GameObject intercom;
    [SerializeField] private GameObject interactionManager;
    private Vector3 _endPos;
    
    // Start is called before the first frame update
    void Start()
    {
        endCamera.Priority = -10;
        equipmentCamera.Priority = 0;
        pileCamera.Priority = 1;
    }

    public void SwitchCamera()
    {
        equipmentCamera.Priority = (equipmentCamera.Priority + 1) % 2;
        pileCamera.Priority = (pileCamera.Priority + 1) % 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SwitchCamera();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SwitchCamera();
        }
    }

    public void OverwriteEndPosition()
    {
        _endPos = interactionManager.GetComponent<InteractionManager>().GetPos();
    }
    
    public void ActivateEndCamera()
    {
        intercom.transform.position = _endPos;
        endCamera.Priority = 10;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera[] cameras;
    [SerializeField] private CinemachineVirtualCamera dollyCamera;
    [SerializeField] private CinemachineVirtualCamera zebCamera;
    [SerializeField] private float moveSpeed;
    
    public void NextCamera()
    {
        if (zebCamera.Priority < 0)
        {
            foreach (CinemachineVirtualCamera c in cameras)
            {
                c.Priority = (c.Priority + 1) % cameras.Length;
            }
        }
    }

    public void PreviousCamera()
    {
        if (zebCamera.Priority < 0)
        {
            foreach (CinemachineVirtualCamera c in cameras)
            {
                c.Priority = (c.Priority - 1) % cameras.Length;
                if (c.Priority < 0)
                {
                    c.Priority += cameras.Length;
                }
            }
        }
    }

    public void ToggleZEB()
    {
        if (zebCamera.Priority < 0)
        {
            zebCamera.Priority *= -1;
        }
        else
        {
            zebCamera.Priority *= -1;
        }
    }

    private void Loop()
    {
        dollyCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += (0.05f) * (moveSpeed * (Time.deltaTime));
        
        if (dollyCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition > 1)
        {
            dollyCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 0;
        }
    }

    private void Update()
    {
        if (dollyCamera.Priority == cameras.Length - 1)
        {
            Loop();
        }
    }
}


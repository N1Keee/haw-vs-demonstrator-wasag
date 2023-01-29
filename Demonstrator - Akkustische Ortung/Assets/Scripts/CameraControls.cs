using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera[] cameras;
    [SerializeField] private CinemachineVirtualCamera zebCamera;
    
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
}


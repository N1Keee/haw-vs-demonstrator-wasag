using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera[] cameras;

    public void NextCamera()
    {
        foreach (CinemachineVirtualCamera c in cameras)
        {
            c.Priority = (c.Priority + 1) % cameras.Length;
        }
    }

    public void PreviousCamera()
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


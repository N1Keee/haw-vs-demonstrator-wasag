using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyLogic : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float moveSpeed;

    public void Loop()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += (0.05f) * (moveSpeed * (Time.deltaTime));
        
        if (virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition > 1)
        {
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 0;
        }
    }
    void Start()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 0;
    }
    
    void Update()
    {
        // Loop();
    }
}

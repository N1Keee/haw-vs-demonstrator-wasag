using System;
using Cinemachine;
using UnityEngine;

[Serializable]
public struct Interaction
{
    public GameObject gameObject;
    public CinemachineVirtualCamera virtualCamera;
    public string instruction;
    public string helpMsg;
    public string errorMsg;
    public bool hasAnimation;
}

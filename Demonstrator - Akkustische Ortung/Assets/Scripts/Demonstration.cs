using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Demonstration
{
    public CinemachineVirtualCamera VirtualCamera;
    public string Instruction;
    public UnityEvent OnExecute;
}

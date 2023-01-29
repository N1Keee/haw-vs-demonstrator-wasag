using System;
using UnityEngine;

[Serializable]
public struct Interaction
{
    public GameObject gameObject;
    public string instruction;
    public string helpMsg;
    public string errorMsg;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Interaction
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private string instruction;
    [SerializeField] private string help;
    [SerializeField] private string error;
    public UnityEvent OnExecution;
    public bool HelpCounted { get; set; }
}

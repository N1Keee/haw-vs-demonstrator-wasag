using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Interaction
{
    public GameObject GameObject;
    public string Instruction;
    public string Help;
    public string Error;
    public UnityEvent OnExecution; 
    public bool HelpCounted { get; set; }

    public Interaction(GameObject gameObject, string instruction, string help, string error) : this()
    {
        GameObject = gameObject;
        Instruction = instruction;
        Help = help;
        Error = error;
    }
}

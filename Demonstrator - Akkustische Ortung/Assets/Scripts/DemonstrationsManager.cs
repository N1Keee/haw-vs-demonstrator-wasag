using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DemonstrationsManager : MonoBehaviour
{
    [SerializeField] private List<Demonstration> demonstrations;
    [SerializeField] private TextMeshProUGUI instructionLabel;

    private bool _demonstrationsCompleted;
    [SerializeField] private float completionCallbackDelay;
    [SerializeField] private UnityEvent OnCompleted;

    private int _i = 0;

    public void LoadDemonstation()
    {
        if (_demonstrationsCompleted)
        {
            return;
        }
        SetCamera(demonstrations[_i].VirtualCamera);
        instructionLabel.text = demonstrations[_i].Instruction;
        demonstrations[_i].OnExecute?.Invoke();
    }

    public void IncrementIndex()
    {
        if (_i == demonstrations.Count)
        {
            return;
        }
        _i++;
    }

    public void DecrementIndex()
    {
        if (_i == 0)
        {
            return;
        }
        _i--;
    }
    
    private void Start()
    {
        LoadDemonstation();
    }

    private void SetCamera(CinemachineVirtualCamera virtualCamera)
    {
        foreach (var demonstration in demonstrations)
        {
            demonstration.VirtualCamera.Priority = 0;
        }
        virtualCamera.Priority = 1;
    }

    private IEnumerator DelayedDemoCompletionCallback()
    {
        yield return new WaitForSeconds(completionCallbackDelay);
        OnCompleted.Invoke();
    }

    public void EndDemo()
    {
        _demonstrationsCompleted = true;
    }
    private void Update()
    {
        if (_demonstrationsCompleted)
        {
            StartCoroutine(DelayedDemoCompletionCallback());
        }
    }
}

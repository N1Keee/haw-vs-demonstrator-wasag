using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmpControler : MonoBehaviour
{
    [SerializeField] private GameObject ampKnob;
    [SerializeField] private GameObject channelKnob;
    [SerializeField] private GameObject filterSwitch;
    [SerializeField] private GameObject highPassKnob;
    [SerializeField] private GameObject lowPassKnob;

    [SerializeField] private float speed;

    private Quaternion _ampKnobOff;
    private Quaternion _ampKnobOn;
    private Quaternion _channelKnobOff;

    
    private void Start()
    {
        _ampKnobOff = ampKnob.transform.rotation;
        _channelKnobOff = channelKnob.transform.rotation;
        _ampKnobOn = new Quaternion(0.48495f, 0.51461f, 0.51461f, -0.48495f);
    }

    public void TurnOn()
    {
        Rotate(ampKnob, _ampKnobOn);
    }

    public void TurnOff()
    {
        Rotate(ampKnob, _ampKnobOff);
    }

    public void SelectChannel(int channel)
    {
        Quaternion targetRotation;
        switch(channel)
        {
            case 0:
                targetRotation = _channelKnobOff;
                break;
            case 1:
                targetRotation = new Quaternion(-0.35684f, 0.61046f, 0.61046f, 0.35684f);
                break;
            case 2:
                targetRotation = new Quaternion(-0.19499f, 0.67969f, 0.67969f, 0.19499f);
                break;
            case 3:
                targetRotation = new Quaternion(-0.01556f, 0.70694f, 0.70694f, 0.01556f);
                break;
            case 4:
                targetRotation = new Quaternion(0.16049f, 0.68865f, 0.68865f, -0.16049f);
                break;
            case 5:
                targetRotation = new Quaternion(0.33856f, 0.62079f, 0.62079f, -0.33856f);
                break;
            case 6:
                targetRotation = new Quaternion(0.49633f, 0.50364f, 0.50364f, -0.49633f);
                break;
            default:
                targetRotation = _channelKnobOff;
                break;
        }
        Rotate(channelKnob, targetRotation);
    }

    public void SwitchFilter(bool on)
    {
        
    }

    public void TurnHighPassOn()
    {
        
    }
    
    public void TurnHighPassOff()
    {
        
    }
    
    public void TurnLowPassOn()
    {
        
    }
    
    public void TurnLowPassOff()
    {
        
    }

    private void Rotate(GameObject from, Quaternion to)
    {
        var step = speed * Time.deltaTime;
        
        from.transform.rotation = Quaternion.RotateTowards(from.transform.rotation, to, step);
    }
}

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
    [SerializeField] private GameObject display;

    [SerializeField] private float speed;
    [SerializeField] private float slowerSpeed;

    private Quaternion _ampKnobOff;
    private Quaternion _ampKnobOn;
    private Quaternion _channelKnobOff;
    private Quaternion _switchOff;
    private Quaternion _switchOn;
    private Quaternion _hpOff;
    private Quaternion _hpOn;
    private Quaternion _lpOff;
    private Quaternion _lpOn;

    
    private void Start()
    {
        _ampKnobOff = ampKnob.transform.rotation;
        _ampKnobOn = new Quaternion(0.48495f, 0.51461f, 0.51461f, -0.48495f);
        _channelKnobOff = channelKnob.transform.rotation;
        _switchOff = filterSwitch.transform.rotation;
        _switchOn = new Quaternion(-0.35355f, 0.61237f, 0.35355f, 0.61237f);
        _hpOff = highPassKnob.transform.rotation;
        _hpOn = new Quaternion(0.25821f, 0.65828f, 0.65828f, -0.25821f);
        _lpOff = lowPassKnob.transform.rotation;
        _lpOn = new Quaternion(-0.34281f, 0.61845f, 0.61845f, 0.34281f);
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
                display.GetComponent<DisplayTexture>().ChangeTexture(1);
                break;
            case 2:
                targetRotation = new Quaternion(-0.19499f, 0.67969f, 0.67969f, 0.19499f);
                display.GetComponent<DisplayTexture>().ChangeTexture(3);
                break;
            case 3:
                targetRotation = new Quaternion(-0.01556f, 0.70694f, 0.70694f, 0.01556f);
                display.GetComponent<DisplayTexture>().ChangeTexture(2);
                break;
            case 4:
                targetRotation = new Quaternion(0.16049f, 0.68865f, 0.68865f, -0.16049f);
                display.GetComponent<DisplayTexture>().ChangeTexture(1);
                break;
            case 5:
                targetRotation = new Quaternion(0.33856f, 0.62079f, 0.62079f, -0.33856f);
                display.GetComponent<DisplayTexture>().ChangeTexture(5);
                break;
            case 6:
                targetRotation = new Quaternion(0.49633f, 0.50364f, 0.50364f, -0.49633f);
                display.GetComponent<DisplayTexture>().ChangeTexture(2);
                break;
            default:
                targetRotation = _channelKnobOff;
                break;
        }
        SlowRotate(channelKnob, targetRotation);
    }

    public void displayChange()
    {
        
    }

    public void SwitchFilter(bool on)
    {
        if (on)
        {
            Rotate(filterSwitch, _switchOn);
        }
        else
        {
            Rotate(filterSwitch, _switchOff);
        }
    }

    public void TurnHighPassOn()
    {
        Rotate(highPassKnob, _hpOn);
    }
    
    public void TurnHighPassOff()
    {
        Rotate(highPassKnob, _hpOff);
    }
    
    public void TurnLowPassOn()
    {
        Rotate(lowPassKnob, _lpOn);
    }
    
    public void TurnLowPassOff()
    {
        Rotate(lowPassKnob, _lpOff);
    }

    private void Rotate(GameObject from, Quaternion to)
    {
        var step = speed * Time.deltaTime;
        
        from.transform.rotation = Quaternion.RotateTowards(from.transform.rotation, to, step);
    }
    
    private void SlowRotate(GameObject from, Quaternion to)
    {
        var step = slowerSpeed * Time.deltaTime;
        
        from.transform.rotation = Quaternion.RotateTowards(from.transform.rotation, to, step);
    }
}

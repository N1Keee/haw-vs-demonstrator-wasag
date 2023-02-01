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

    [SerializeField] private float rSpeed;

    public void TurnOn()
    {
        var zPos = Mathf.Rad2Deg * ampKnob.transform.rotation.z;
        if (zPos < 178f)
        {
            Rotate(ampKnob, true);
        }
    }

    public void TurnOff()
    {
        var zPos = Mathf.Rad2Deg * ampKnob.transform.rotation.z;
        if (zPos > 45f)
        {
            Rotate(ampKnob, false);
        }
    }

    public void SelectChannel(int channel)
    {
        
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

    private void Rotate(GameObject target, bool positive)
    {
        if (positive)
        {
            target.transform.Rotate(0,0,rSpeed * Time.deltaTime);
        }
        else
        {
            target.transform.Rotate(0,0,-rSpeed * Time.deltaTime);
        }
        
    }

}

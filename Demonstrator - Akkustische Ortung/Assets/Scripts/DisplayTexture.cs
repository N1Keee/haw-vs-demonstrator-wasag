using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTexture : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject channelKnob;
    [SerializeField] private GameObject ampKnob;
    
    private Renderer _meshRenderer;
    
    [SerializeField] private Texture2D[] localTexture2Ds;
    [SerializeField] private Texture2D offTexture;
    [SerializeField] private Texture2D allTexture;

    void Start()
    {
        _meshRenderer = display.GetComponent<MeshRenderer>();
    }

    private void UpdateDisplay()
    {
        if (ampKnob.transform.rotation.eulerAngles.y > 170)
        {
            if (channelKnob.transform.rotation.eulerAngles.y < 111 && channelKnob.transform.rotation.eulerAngles.y > 85)
            {
                _meshRenderer.material.mainTexture = allTexture;
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 138 && channelKnob.transform.rotation.eulerAngles.y > 111)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[0];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 166 && channelKnob.transform.rotation.eulerAngles.y > 138)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[1];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 195 && channelKnob.transform.rotation.eulerAngles.y > 166)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[2];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 225 && channelKnob.transform.rotation.eulerAngles.y > 195)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[3];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 255 && channelKnob.transform.rotation.eulerAngles.y > 225)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[4];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 285 && channelKnob.transform.rotation.eulerAngles.y > 255)
            {
                _meshRenderer.material.mainTexture = localTexture2Ds[5];
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 315 && channelKnob.transform.rotation.eulerAngles.y > 285)
            {
                _meshRenderer.material.mainTexture = offTexture;
            }
            if (channelKnob.transform.rotation.eulerAngles.y < 345 && channelKnob.transform.rotation.eulerAngles.y > 315)
            {
                _meshRenderer.material.mainTexture = offTexture;
            }
        }
        else
        {
            _meshRenderer.material.mainTexture = offTexture;
        }
        
    }

    private void Update()
    {
        UpdateDisplay();
    }
}

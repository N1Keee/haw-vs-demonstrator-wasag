using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    [SerializeField] private GameObject[] geophones; // all geophones
    [SerializeField] private Texture2D[] textures; // all textures
    [SerializeField] private Texture2D[] localTexture2Ds;

    [SerializeField] private GameObject display;
    private MeshRenderer _meshRenderer;
    [SerializeField] private GameObject channelKnob;

    private bool _texturesOverwritten = false;
    private bool _localTexture2DsOverwritten = false;
    private GameObject _geophone; // the random geophone from interactionsManager
    [SerializeField] private Texture2D targetTexture; // maxed out channel texture
    [SerializeField] private Texture2D offTexture;

    [SerializeField] private InteractionManager interactionManager;  // implement getGeophone();

    public void OverwriteGeophone() => _geophone = interactionManager.GetComponent<InteractionManager>().GetGeophone();

    public void OverwriteTextures()
    {
        for (int i = 0; i < geophones.Length; i++)
        {
            if (geophones[i].Equals(_geophone))
            {
                textures[i] = targetTexture;
            }
        }
        for (int i = 0; i < textures.Length; i++)
        {
            geophones[i].GetComponent<TextureHandler>().SetTexture2D(textures[i]);
        }
        _texturesOverwritten = true;
    }

    public void OverwriteLocalTextures()
    {
        for (int i = 0; i < geophones.Length; i++)
        {
            localTexture2Ds[i] = geophones[i].GetComponent<TextureHandler>().GetTexture2D();
        }
        Debug.Log(localTexture2Ds.Length);
        _localTexture2DsOverwritten = true;
    }
    private void Start()
    {
        _meshRenderer = display.transform.GetComponent<MeshRenderer>();
        _meshRenderer.material.mainTexture = offTexture;
    }

    private void Update()
    {
        if (_texturesOverwritten && _localTexture2DsOverwritten)
        {
            DisplayTexture();
        } 
    }

    private void DisplayTexture()
    {
        if (channelKnob.transform.rotation.eulerAngles.y < 111 && channelKnob.transform.rotation.eulerAngles.y > 85)
        {
            _meshRenderer.material.mainTexture = offTexture;
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
}

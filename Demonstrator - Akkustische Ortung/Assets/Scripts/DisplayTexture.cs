using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTexture : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private Texture[] textures;
    private Renderer _displayRenderer;

    void Start()
    {
        _displayRenderer = display.GetComponent<Renderer>();
    }

    public void ChangeTexture(int i)
    {
        _displayRenderer.material.mainTexture = textures[i];
    }
}

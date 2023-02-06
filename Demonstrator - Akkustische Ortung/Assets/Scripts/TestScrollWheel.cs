using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrollWheel : MonoBehaviour  // rename !!!
{
    private bool _scrollEnabled;
    [SerializeField] private GameObject channelKnob;
    [SerializeField] private float scrollSpeed;
    private Material _defaultMaterial;

    [SerializeField] private Material highlightMaterial;
    // Start is called before the first frame update
    private void Awake()
    {
        _scrollEnabled = false;
        _defaultMaterial = channelKnob.GetComponent<MeshRenderer>().material;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_scrollEnabled)
        {
            var speed = Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime;
            channelKnob.transform.Rotate(0,0,speed * scrollSpeed);
        }
    }

    public void ToggleScrollable()
    {
        _scrollEnabled = !_scrollEnabled;
        if (_scrollEnabled)
        {
            channelKnob.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
        else
        {
            channelKnob.GetComponent<MeshRenderer>().material = _defaultMaterial;
        }
    }
}

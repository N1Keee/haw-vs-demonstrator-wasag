using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour       // can be deleted !!!
{
    public LineRenderer lineRenderer;
    [SerializeField] private Transform[] positions;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = positions.Length;
    }
    
    public void DrawLines()
    {
        if (!lineRenderer.gameObject.activeSelf)
        {
            lineRenderer.transform.gameObject.SetActive(true);
        }
        for (int i = 0; i < positions.Length; i++)
        {
            lineRenderer.SetPosition(i, positions[i].position);
        }
    }

    public void HideLines()
    {
        lineRenderer.transform.gameObject.SetActive(false);
    }
}

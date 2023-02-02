using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
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
        for (int i = 0; i < positions.Length; i++)
        {
            lineRenderer.SetPosition(i, positions[i].position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomMover : MonoBehaviour
{
    [SerializeField] private float speed;
    public LineRenderer lineRenderer;

    private Vector3 _startingPosition;
    private float _yBorder;
    void Start()
    {
        _startingPosition = transform.position;
        _yBorder = _startingPosition.y - 1;
        lineRenderer.positionCount = 2;
    }

    public void Deploy()
    {
        var step = speed * Time.deltaTime;
        if (transform.position.y > _yBorder)
        {
            transform.Translate(new Vector3(0,-step,0));
        }
        lineRenderer.SetPosition(0, _startingPosition);
        lineRenderer.SetPosition(1, transform.position);
    }
    public void ReDeploy()
    {
        var step = speed * Time.deltaTime;
        if (transform.position.y > _startingPosition.y)
        {
            transform.Translate(new Vector3(0,step,0));
        }
    }
}

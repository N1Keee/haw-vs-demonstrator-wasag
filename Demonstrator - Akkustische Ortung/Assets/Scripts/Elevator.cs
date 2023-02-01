using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float ySpeed;
    private float _yBorder;
    private float _yRoot;
    public bool upwards;

    private void Start()
    {
        upwards = true;
        _yRoot = transform.position.y;
        _yBorder = _yRoot + 1;
    }

    private void MoveAccordingly()
    {
        if (upwards)
        {
            if (transform.position.y < _yBorder)
            {
                transform.Translate(new Vector3(0,1 * (ySpeed * Time.deltaTime),0));
            }
        }
        else
        {
            if (transform.position.y > _yRoot)
            {
                transform.Translate(new Vector3(0,1 * (-ySpeed * Time.deltaTime),0));
            }
        }
    }

    private void Update()
    {
        MoveAccordingly();
    }
}

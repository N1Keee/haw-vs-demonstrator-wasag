using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomCable : MonoBehaviour
{
    [SerializeField] private GameObject intercom;
    private Animator _animator;
    [SerializeField] private GameObject intercomCable;
    private Vector3 _offset;
    
    private void Start()
    {
        _offset = new Vector3(0.0405f,1.027f, -0.136f);
        _animator = intercom.GetComponent<Animator>();
    }

    private void MoveAlong()
    {
        intercomCable.transform.position = intercom.transform.position + _offset;
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("DeployIntercom"))
        {
            MoveAlong();
        }
    }
    
    
}

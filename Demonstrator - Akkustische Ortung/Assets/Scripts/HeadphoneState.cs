using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphoneState : MonoBehaviour
{
    private Animator _animator;
    private void Awake() => _animator = transform.GetComponent<Animator>();
    
    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Mounted"))
        {
            transform.gameObject.SetActive(false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            transform.gameObject.SetActive(true);
        }
    }
}

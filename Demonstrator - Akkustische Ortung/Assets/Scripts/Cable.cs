using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField] private GameObject geophone;
    [SerializeField] private GameObject cable;
    private Animator _animator;

    private void ShowHide()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Placed") || _animator.GetCurrentAnimatorStateInfo(0).IsName("Placed_demo"))
        {
            cable.gameObject.SetActive(true);
        }
        else
        {
            cable.gameObject.SetActive(false);
        }
    }
    
    private void Start()
    {
        _animator = geophone.GetComponent<Animator>();
    }

    private void Update()
    {
        ShowHide();
    }
}

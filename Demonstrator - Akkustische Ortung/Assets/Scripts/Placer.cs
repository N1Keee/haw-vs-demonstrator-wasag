using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Placer : MonoBehaviour
{
    [SerializeField] private GameObject[] geophones;
    [SerializeField] private Animator[] animators;

    private void Start()
    {
        for (int i = 0; i < geophones.Length; i++)
        {
            animators[i] = geophones[i].GetComponent<Animator>();
        }
    }

    public void PlaceGeophones()
    {
        foreach (var animator in animators)
        {
            animator.SetTrigger("Place");
        }
    }

    public void ReplaceGeophones()
    {
        foreach (var animator in animators)
        {
            animator.Rebind();
            animator.Update(0f);
        }
    }
}

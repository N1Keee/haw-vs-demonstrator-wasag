using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntercomMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gap;
    private float _border;
    [SerializeField] private GameObject intercomOne;
    [SerializeField] private GameObject intercomTwo;

    private void Start()
    {
        _border = intercomTwo.transform.position.y - gap;
    }

    public void Deploy()
    {
        intercomOne.gameObject.SetActive(false);
        intercomTwo.gameObject.SetActive(true);

        var step = speed * Time.deltaTime;
        if (intercomTwo.transform.position.y > _border)
        {
            intercomTwo.transform.Translate(new Vector3(0,-step,0));
        }
    }
}

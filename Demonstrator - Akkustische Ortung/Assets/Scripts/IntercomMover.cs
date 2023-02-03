using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class IntercomMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gap;
    private Vector3 _origin;
    private Vector3 _cableOrigin;
    private float _border;
    private float _blendBorder;
    [SerializeField] private GameObject intercomOne;
    [SerializeField] private GameObject intercomTwo;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject cable;

    private void Start()
    {
        _border = intercomTwo.transform.position.y - gap;
        _origin = intercomTwo.transform.position;
        _cableOrigin = cable.transform.position;
        _blendBorder = intercomTwo.transform.position.y - gap / 2;
    }

    public void Deploy()
    {
        //intercomOne.gameObject.SetActive(false);
        intercomTwo.gameObject.SetActive(true);
        cable.gameObject.SetActive(true);

        var step = speed * Time.deltaTime;
        if (intercomTwo.transform.position.y > _border)
        {
            intercomTwo.transform.Translate(new Vector3(0,-step,0));
            cable.transform.Translate(new Vector3(0,-step,0));
        }
    }

    public void ReDeploy()
    {
        intercomOne.gameObject.SetActive(true);
        intercomTwo.gameObject.SetActive(false);
        cable.gameObject.SetActive(false);

        intercomTwo.transform.position = _origin;
        cable.transform.position = _cableOrigin;
    }

    private void Update()
    {
        if(intercomTwo.transform.gameObject.activeSelf)
        {
            if (intercomTwo.transform.position.y < _blendBorder)
            {
                virtualCamera.Priority = 2;
                if (intercomTwo.transform.position.y < _blendBorder - 0.25f)
                {
                    intercomOne.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (intercomTwo.transform.position.y > _blendBorder)
            {
                virtualCamera.Priority = 0;
                intercomTwo.gameObject.SetActive(false);
                cable.gameObject.SetActive(false);
            }
        }
    }
}

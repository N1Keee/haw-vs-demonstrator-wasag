using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    [SerializeField] private GameObject[] geophones;
    [SerializeField] private Vector3[] rootPositions;
    [SerializeField] private Quaternion[] rootRotations;
    
    [SerializeField] private Vector3[] placedPositions;
    [SerializeField] private Quaternion[] placedRotations;
    
    public void PlaceOnPile()
    {
        for(int e = 0; e < geophones.Length; e++)
        {
            geophones[e].transform.localPosition = placedPositions[e];
            geophones[e].transform.localRotation = placedRotations[e];
        }
    }

    public void PlaceAtEquipment()
    {
        for(int e = 0; e < geophones.Length; e++)
        {
            geophones[e].transform.localPosition = rootPositions[e];
            geophones[e].transform.localRotation = rootRotations[e];
        }
    }

}

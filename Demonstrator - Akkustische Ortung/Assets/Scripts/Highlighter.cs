using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private GameObject[] debrisPieces;

    public void Highlight()
    {
        Debug.Log("highlighting...");
        foreach (var piece in debrisPieces)
        {
            piece.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
    }
    
    public void DeHighlight()
    {
        Debug.Log("dehighlighting...");
        foreach (var piece in debrisPieces)
        {
            piece.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private GameObject[] debrisPieces;

    public void Highlight()
    {
        foreach (var piece in debrisPieces)
        {
            piece.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
    }
    
    public void DeHighlight()
    {
        foreach (var piece in debrisPieces)
        {
            piece.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
    
    public void HighlightPiece(int i)
    {
        debrisPieces[i].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
    
    public void DeHighlightPiece(int i)
    {
        debrisPieces[i].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
    }
}

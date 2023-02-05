using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    public void DisableColliders()
    {
        BoxCollider[] colliders = transform.GetComponents<BoxCollider>();
        foreach (var boxCollider in colliders)
        {
            boxCollider.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureHandler : MonoBehaviour
{
    [SerializeField] private Texture2D texture;

    public Texture2D GetTexture2D()
    {
        return texture;
    }

    public void SetTexture2D(Texture2D t)
    {
        texture = t;
    }
}

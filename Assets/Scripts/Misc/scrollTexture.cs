using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{

    public GameObject quadGameObject;
    private Renderer quadRenderer;

    public float scrollSpeed = 0.5f;

    void Start()
    {
        quadRenderer = quadGameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(0, Time.time * scrollSpeed);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
}

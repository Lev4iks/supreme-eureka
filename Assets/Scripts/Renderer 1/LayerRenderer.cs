using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class LayerRenderer : MonoBehaviour
{
    [SerializeField]
    private int baseLayer = 5000;

    [SerializeField]
    private float offSet = 0f;

    [SerializeField]
    private bool runOnlyOnce = true;

    private Renderer myRenderer;


    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        InvokeRepeating("RenderObject", 0.1f, 0.3f);
    }

    private void RenderObject()
    {
        myRenderer.sortingOrder = (int)(baseLayer - transform.position.y * 10 - offSet);
        if (runOnlyOnce)
            Destroy(this);
    }
}

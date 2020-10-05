using System;
using UnityEngine;

public class ThinkPoint : MonoBehaviour
{
    private Collider2D _collider2D;
    public Dialog dialog;
        

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<ThinkAction>().Think(dialog);
            Destroy(gameObject);
        }
    }
    
}
using System;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private Collider2D _collider2D;
    public Dialog dialog;


    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Created");
            InterfaceOnScene.Instance.CreateDialogWindow(transform, dialog.characterName, dialog.sentences[0]);
        }
    }
    
}
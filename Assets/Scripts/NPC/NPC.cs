using System;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private Collider2D _collider2D;
    private TalkEvent _talkEvent;
    public Dialog dialog;


    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _talkEvent = GetComponentInChildren<TalkEvent>();
    }

}
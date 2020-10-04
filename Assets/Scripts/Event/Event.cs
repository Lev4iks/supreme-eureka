using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Event : MonoBehaviour
{
    private BoxCollider2D eventTrigger;
    protected bool isDone = false;
    protected Pointer _pointer;
    protected EventManager _eventManager;
    
    [SerializeField] protected float eventRange = 2f;

    
    protected virtual void Start()
    {
        eventTrigger = GetComponent<BoxCollider2D>();
        eventTrigger.size = new Vector2(eventRange, eventRange);
        eventTrigger.isTrigger = true;
        _eventManager = OfficeTimeManager.Instance.GetComponent<EventManager>();

        _pointer = GetComponentInChildren<Pointer>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCamera.Instance.Zoom(new Vector3(0, 0, -10), gameObject.transform.position);
            EventTrigger();
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventExit();
            PlayerCamera.Instance.Zoom(new Vector3(0, 0, -30), Vector3.zero);
        }
    }

    public virtual void EventTrigger()
    {

    }

    public virtual void EventExit()
    {
        
    }
    
}

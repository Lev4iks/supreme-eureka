using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Event : MonoBehaviour, Interaction
{
    private BoxCollider2D eventTrigger;
    protected bool isDone = false;
    protected Pointer _pointer;
    protected EventManager _eventManager;
    protected PlayerAnimations _playerAnimations;

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
            EventTrigger();
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            EventExit();
    }

    public virtual void EventTrigger()
    {
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.eventOffset, gameObject.transform.position);
    }

    public virtual void EventExit()
    {
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.mainOffset, Vector3.zero);
    }
    
    public virtual void Interact()
    {
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.mainOffset, Vector3.zero);
    }
    
}

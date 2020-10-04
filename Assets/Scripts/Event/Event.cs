using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Event : MonoBehaviour, IInteraction
{
    private BoxCollider2D eventTrigger;
    protected bool isDone = false;
    protected Pointer pointer;
    protected EventManager eventManager;
    
    protected PlayerBase player;
    protected Movement movement;
    protected PlayerAnimations playerAnimations;

    [SerializeField] protected float eventRange = 2f;

    
    protected virtual void Start()
    {
        eventTrigger = GetComponent<BoxCollider2D>();
        eventTrigger.size = new Vector2(eventRange, eventRange);
        eventTrigger.isTrigger = true;
        eventManager = OfficeTimeManager.Instance.GetComponent<EventManager>();

        player = PlayerBase.Instance;
        movement = player.GetComponent<Movement>();
        playerAnimations = player.GetComponent<PlayerAnimations>();
        
        pointer = GetComponentInChildren<Pointer>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            EventTrigger();
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            EventExit();
    }

    public virtual void EventTrigger()
    {
        player.SetInteraction(this);
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.eventOffset, gameObject.transform.position);
    }

    public virtual void EventExit()
    {
        player.SetInteraction(null);
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.mainOffset, Vector3.zero);
    }
    
    public virtual void Interact()
    {
        PlayerCamera.Instance.Zoom(PlayerCamera.Instance.mainOffset, Vector3.zero);
    }
    
}

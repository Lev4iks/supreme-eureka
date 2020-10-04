﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeEvent : Event, Interaction
{
    public float DrinkTime = 30f;

    private PlayerBase _player;
    private Movement _movement;
    private IEnumerator coroutine;
    private Vector2 _savedPosition;
    private bool _courantineHasStarted = false;

    protected override void Start()
    {
        base.Start();
        _player = PlayerBase.Instance;
        _movement = _player.GetComponent<Movement>();
        _playerAnimations = _player.GetComponent<PlayerAnimations>();
    }

    public override void EventTrigger()
    {
        _pointer.SetPointer(PointerType.FButton);
        _player.SetInteraction(this);
    }

    public override void EventExit()
    {
        _pointer.SetPointer(PointerType.TaskArrow);
        _player.SetInteraction(null);
    }

    public void Interact()
    {
        Debug.Log("Drinking Coffe");
        _playerAnimations.TriggerInteraction(1);    // 0 - work, 1 - drink, 2 - chat, printer
        _pointer.SetState(false);

        if (!_courantineHasStarted)
            StartCoroutine(WorkingTime());

        //Move Player to the position
        _savedPosition = _player.gameObject.transform.position;
        _player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime()
    {
        _courantineHasStarted = true;
        _movement.DisableMovement();

        yield return new WaitForSeconds(DrinkTime);

        _player.gameObject.transform.position = _savedPosition;
        _movement.StartMoving();
        _playerAnimations.StopDrinking(); 
        _courantineHasStarted = false;

        _eventManager.SwitchEvent();

    }

}

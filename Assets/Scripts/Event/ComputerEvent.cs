﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerEvent : Event,Interaction
{
    public float WorkTime = 60f;

    private PlayerBase _player;
    private Movement _movement;
    private IEnumerator coroutine;
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
        _playerAnimations.TriggerInteraction(0);

        _pointer.SetState(false);

        Time.timeScale = 2;

        coroutine = WorkingTime(WorkTime);
        if(!_courantineHasStarted)
            StartCoroutine(coroutine);

        //Move Player to the position
        _player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime(float waitTime)
    {
        _courantineHasStarted = true;
        _movement.DisableMovement();
        
        yield return new WaitForSeconds(waitTime);

        Time.timeScale = 1;
        _movement.StartMoving();
        _playerAnimations.StopWorking();

        _courantineHasStarted = false;

        _eventManager.SwitchEvent();

        Debug.Log("Need some coffe");
    }
    
}

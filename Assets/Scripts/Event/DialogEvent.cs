using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : Event, Interaction
{
    private PlayerBase _player;
    private Movement _movement;


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
        Debug.Log("Talks");

        _playerAnimations.TriggerInteraction(0);    // 0 - work, 1 - drink, 2 - chat, printer

        _pointer.SetState(false);
        _movement.DisableMovement();

        //Move Player to the position
        _player.gameObject.transform.position = gameObject.transform.position;

        //Stop time
        OfficeTimeManager.Instance.StopTime();

        //Dialog here: ->

        //Resume the time after finishing the dialog

        _movement.StartMoving();
        OfficeTimeManager.Instance.ResumeTime();
    }
}

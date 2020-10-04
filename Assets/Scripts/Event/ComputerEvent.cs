using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerEvent : Event,IInteraction
{
    public float WorkTime = 30f;
    
    private IEnumerator coroutine;
    private bool _courantineHasStarted = false;
    

    public override void EventTrigger()
    {
        pointer.SetPointer(PointerType.FButton);
        base.EventTrigger();
    }

    public override void EventExit()
    {
        pointer.SetPointer(PointerType.TaskArrow);
        base.EventExit();
    }

    public override void Interact()
    {
        playerAnimations.TriggerInteraction(0);

        pointer.SetState(false);

        Time.timeScale = 2;

        coroutine = WorkingTime(WorkTime);
        if(!_courantineHasStarted)
            StartCoroutine(coroutine);

        //Move Player to the position
        player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime(float waitTime)
    {
        _courantineHasStarted = true;
        movement.DisableMovement();
        
        yield return new WaitForSeconds(waitTime);

        Time.timeScale = 1;
        movement.EnableMovement();
        playerAnimations.StopWorking();

        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        base.Interact(); // Moves camera
    }
    
}

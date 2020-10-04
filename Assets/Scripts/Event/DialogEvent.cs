using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : Event, IInteraction
{

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
        Debug.Log("Talks");

        playerAnimations.TriggerInteraction(InteractionType.Work);

        pointer.SetState(false);
        movement.DisableMovement();

        //Move Player to the position
        player.gameObject.transform.position = gameObject.transform.position;

        //Stop time
        OfficeTimeManager.Instance.StopTime();

        //Dialog here: ->

        //Resume the time after finishing the dialog

        movement.EnableMovement();
        OfficeTimeManager.Instance.ResumeTime();
        base.Interact(); // Moves camera
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeEvent : Event, IInteraction
{
    public float DrinkTime = 30f;
    
    private IEnumerator coroutine;
    private Vector2 _savedPosition;
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
        playerAnimations.TriggerInteraction(InteractionType.Drink);
        pointer.SetState(false);

        if (!_courantineHasStarted)
            StartCoroutine(WorkingTime());

        //Move Player to the position
        _savedPosition = player.gameObject.transform.position;
        player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime()
    {
        _courantineHasStarted = true;

        yield return new WaitForSeconds(DrinkTime);

        player.gameObject.transform.position = _savedPosition;
        movement.EnableMovement();
        playerAnimations.StopDrinking(); 
        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        base.Interact(); // Moves camera
    }

}

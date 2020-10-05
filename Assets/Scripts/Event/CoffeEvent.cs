using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class CoffeEvent : Event, IInteraction
{
    public float DrinkTime = 30f;

    [SerializeField]
    private AudioClip interactSound;
    [SerializeField]
    private AudioClip actionSound;
    [SerializeField]
    private AudioSource audioSource;

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
        audioSource.PlayOneShot(interactSound);
        playerAnimations.TriggerInteraction(InteractionType.Drink);
        pointer.SetState(false);

        if (!_courantineHasStarted)
            StartCoroutine(WorkingTime());
    }

    private IEnumerator WorkingTime()
    {
        _courantineHasStarted = true;
        audioSource.PlayOneShot(actionSound);
        yield return new WaitForSeconds(DrinkTime);
        
        movement.EnableMovement();
        playerAnimations.StopDrinking(); 
        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        pointer.SetState(true);
        base.Interact(); // Moves camera
    }

}

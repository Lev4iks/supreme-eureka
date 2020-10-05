using System.Collections;
using UnityEngine;

public class CopyingEvent : Event
{
    public float workTime = 15f;

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
        //playerAnimations.TriggerInteraction(InteractionType.Copy);
        pointer.SetState(false);

        if (!_courantineHasStarted)
            StartCoroutine(WorkingTime());
    }

    private IEnumerator WorkingTime()
    {
        _courantineHasStarted = true;
        audioSource.PlayOneShot(actionSound);
        yield return new WaitForSeconds(workTime);
        
        movement.EnableMovement();
        //playerAnimations.StopCopying(); 
        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        pointer.SetState(true);
        base.Interact(); // Moves camera
    }
    
}
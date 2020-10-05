using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]

public class ComputerEvent : Event,IInteraction
{
    public float WorkTime = 30f;
    
    private IEnumerator coroutine;
    private bool _courantineHasStarted = false;
    [SerializeField]
    private AudioClip interactSound;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject chair;


    private void SetChairVisible(bool state)
    {
        chair.SetActive(state);
    }
    
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
        audioSource.PlayOneShot(interactSound);

        pointer.SetState(false);

        Time.timeScale = 2;
        OfficeTimeManager.Instance.ResumeTime();

        coroutine = WorkingTime(WorkTime);
        if(!_courantineHasStarted)
            StartCoroutine(coroutine);

        //Move Player to the position
        player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime(float waitTime)
    {
        SetChairVisible(false);
        _courantineHasStarted = true;
        movement.DisableMovement();

        yield return new WaitForSeconds(waitTime);

        Time.timeScale = 1;
        OfficeTimeManager.Instance.StopTime();

        movement.EnableMovement();
        playerAnimations.StopWorking();

        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        pointer.SetState(true);
        base.Interact(); // Moves camera
        SetChairVisible(true);
    }
    
}

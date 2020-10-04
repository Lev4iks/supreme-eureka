using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkEvent : Event, IInteraction
{
    private bool isTalking = false;
    private Dialog _dialog;
    private DialogManager _dialogManager;
    private Transform _character;

    protected override void Start()
    {
        base.Start();
        pointer.SetPointer(PointerType.FButton);
        pointer.SetState(false);
        _dialogManager = GetComponent<DialogManager>();
    }
    
    public override void EventTrigger()
    {
        pointer.SetState(true);
        base.EventTrigger();
    }

    public override void EventExit()
    {
        pointer.SetState(false);
        base.EventExit();
    }

    private void StartDialog()
    {
        pointer.SetState(false);
        movement.DisableMovement();
        
        //Stop time
        OfficeTimeManager.Instance.StopTime();

        _dialogManager.StartDialog();
        isTalking = true;
    }

    private void EndDialog()
    {
        movement.EnableMovement();
        OfficeTimeManager.Instance.ResumeTime();
        base.Interact(); // Moves camera
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.E))
            if (!_dialogManager.Talk())
                EndDialog();
    }

    public override void Interact()
    {
        StartDialog();
    }
    
}

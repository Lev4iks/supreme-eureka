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
        player.SetInteraction(this);
        pointer.SetState(true);
    }

    public override void EventExit()
    {
        player.SetInteraction(null);
        pointer.SetState(false);
    }

    private void StartDialog()
    {
        pointer.SetState(false);
        movement.DisableMovement();
        GetComponentInParent<NPCPath>().SetMovement(false);
        
        //Stop time
        OfficeTimeManager.Instance.StopTime();

        _dialogManager.StartDialog();
        isTalking = true;
    }

    private void EndDialog()
    {
        isTalking = false;
        movement.EnableMovement();
        GetComponentInParent<NPCPath>().SetMovement(true);
        
        OfficeTimeManager.Instance.ResumeTime();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.F))
            if (!_dialogManager.Talk())
                EndDialog();
    }

    public override void Interact()
    {
        StartDialog();
    }
    
}

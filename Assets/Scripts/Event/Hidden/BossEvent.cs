using System;
using System.Collections;
using UnityEngine;

public class BossEvent : HiddenEvent
{
    private bool _coroutineStarted = false;
    private GameObject _dialogWindow;
    private Dialog _dialog;
    public GameObject boss;
    public int dialogTime = 3;

    
    protected override void Start()
    {
        base.Start();
        _dialogWindow = Resources.Load<GameObject>("DialogWindow");
        _dialog = boss.GetComponent<NPC>().dialog;
    }
    
    public override void Interact()
    {
        if (!_coroutineStarted)
            StartCoroutine(Talk(_dialog.sentences[0]));
    }

    private IEnumerator Talk(String dialog)
    {
        movement.EnableMovement();
        _coroutineStarted = true;
        GameObject dWindow = InterfaceOnScene.Instance.CreateDialogWindow(boss.transform, dialog);
        yield return new WaitForSeconds(dialogTime);
        Destroy(dWindow);
        _coroutineStarted = false;
        Destroy(gameObject);
    }
    
}
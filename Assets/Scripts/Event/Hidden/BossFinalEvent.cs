using System;
using System.Collections;
using UnityEngine;

public class BossFinalEvent : HiddenEvent
{
    private bool _coroutineStarted = false;
    private GameObject _dialogWindow;
    private Dialog _dialog;
    private int _index = 0;
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
            StartCoroutine(Talk(_dialog.sentences[_index]));
    }

    private IEnumerator Talk(String dialog)
    {
        _index++;

        movement.EnableMovement();
        _coroutineStarted = true;
        GameObject dWindow = InterfaceOnScene.Instance.CreateBossDialogWindow(boss.transform, dialog);
        yield return new WaitForSeconds(dialogTime);
        Destroy(dWindow);
        _coroutineStarted = false;
        if (_index > 2)
            OfficeTimeManager.Instance.isWinBoss = true;
    }

}
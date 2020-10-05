using System;
using System.Collections;
using UnityEngine;


public class ThinkAction : MonoBehaviour
{
    private GameObject _dialogWindow;
    private bool _coroutineStarted = false;
    public int thinkTime = 5;

    
    private void Start()
    {
        _dialogWindow = Resources.Load<GameObject>("DialogWindow");
    }

    public void Think(Dialog dialog)
    {
        if (!_coroutineStarted)
            StartCoroutine(Thinking(dialog.sentences[0]));
    }

    private IEnumerator Thinking(String dialog)
    {
        _coroutineStarted = true;
        GameObject dWindow = InterfaceOnScene.Instance.CreateSelfDialogWindow(transform, dialog);
        yield return new WaitForSeconds(thinkTime);
        Destroy(dWindow);
        _coroutineStarted = false;
    }
    
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private int _index = 0;
    private GameObject _dWindow;
    private Dialog _dialog;
    

    private void Start()
    {
        _dialog = GetComponentInParent<NPC>().dialog;
        transform.position += new Vector3(1, 1);
    }

    public bool Talk()
    {
        Destroy(_dWindow);
        if (_dialog.sentences.Length > _index) 
        {
            _dWindow = InterfaceOnScene.Instance.CreateDialogWindow
                (transform, _dialog.characterName, _dialog.sentences[_index]);
            _index++;
            return true;
        }
        
        return false;
    }

    public void StartDialog()
    {
        _dWindow = InterfaceOnScene.Instance.CreateDialogWindow
            (transform, _dialog.characterName, _dialog.sentences[_index]);
        _index++;
    }

}
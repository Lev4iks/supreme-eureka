using System;
using TMPro;
using UnityEngine;


public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialog;


    public void SetOptions(string characterName, string dialog)
    {
        this.characterName.SetText(characterName);
        this.dialog.SetText(dialog);
    }
    
}
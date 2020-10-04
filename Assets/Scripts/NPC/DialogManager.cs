using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogText;
    

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        nameText.text = dialog.characterName;
        sentences.Clear();

        foreach (var sentence in dialog.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    public void EndDialog()
    {
        
    }
    
}
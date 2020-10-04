using System;
using UnityEngine;

[Serializable]
public class Dialog 
{
    public string characterName;
    [TextArea(3, 10)]
    public string[] sentences;

}
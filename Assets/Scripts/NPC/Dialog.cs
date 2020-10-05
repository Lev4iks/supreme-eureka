using System;
using UnityEngine;

[Serializable]
public class Dialog 
{
    [TextArea(3, 10)]
    public string[] sentences;
}
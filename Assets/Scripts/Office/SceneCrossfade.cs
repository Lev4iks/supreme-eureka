using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class SceneCrossfade : MonoBehaviour
{
    Animator animator;

   
    void Start()
    {
        animator = GetComponent<Animator>();
        InterfaceOnScene.Instance.SetDayName((OfficeTimeManager.Instance.NextScene - 1).ToString());
        InterfaceOnScene.Instance.TriggerDayLabel();
    }

    public void TriggerCrossfade(bool option)
    {
        if(!option)
            animator.SetTrigger("FadeOut");
    }
}

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
        InterfaceOnScene.Instance.SetDayName(OfficeTimeManager.Instance.SceneName);
        InterfaceOnScene.Instance.TriggerDayLabel();
    }

    public void TriggerCrossfade(bool option)
    {
        if (!option)
            animator.SetTrigger("FadeOut");
    }
}

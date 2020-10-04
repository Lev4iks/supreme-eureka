using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerInteraction(int index)
    {
        animator.SetTrigger("Interact");
        switch (index)
        {
            //Working
            case 0:
                {
                    animator.SetBool("Work",true);
                    break;
                }
            //Drinking
            case 1:
                {
                    animator.SetBool("Drink", true);
                    break;
                }
            //Speaking or printing
            case 2:
                {
                    //coming soon...
                    break;
                }
        }
    }
    
    public void StopDrinking()
    {
        animator.SetBool("Drink", false);
    }

    public void StopWorking()
    {
        animator.SetBool("Work", false);
    }
}

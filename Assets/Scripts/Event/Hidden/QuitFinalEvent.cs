using System.Collections;
using UnityEngine;

public class QuitFinalEvent : HiddenEvent
{
    public Dialog dialog;


    public override void Interact()
    {
        movement.DisableMovement();
        PlayerBase.Instance.GetComponent<ThinkAction>().Think(dialog);
        StartCoroutine(Think());
    }

    private IEnumerator Think()
    {
        yield return new WaitForSeconds(3);
        player.SetInteraction(null);
        Destroy(gameObject);
        OfficeTimeManager.Instance.isWinQuit = true;
    }

}
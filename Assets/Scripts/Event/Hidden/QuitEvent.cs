using UnityEngine;

public class QuitEvent : HiddenEvent
{
    public Dialog dialog;


    public override void Interact()
    {
        movement.EnableMovement();
        PlayerBase.Instance.GetComponent<ThinkAction>().Think(dialog);
        player.SetInteraction(null);
        Destroy(gameObject);
    }
    
}
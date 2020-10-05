public class QuitFinalEvent : HiddenEvent
{
    public Dialog dialog;


    public override void Interact()
    {
        movement.DisableMovement();
        PlayerBase.Instance.GetComponent<ThinkAction>().Think(dialog);
        player.SetInteraction(null);
        Destroy(gameObject);

        OfficeTimeManager.Instance.isWinQuit = true;
    }

}
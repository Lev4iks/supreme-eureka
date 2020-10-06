using System.Collections;
using UnityEngine;

public class CoffeeDialogEvent : Event
{
    public float DrinkTime = 15f;
    public float talkTime = 3f;

    [SerializeField]
    private AudioClip interactSound;
    [SerializeField]
    private AudioClip actionSound;
    [SerializeField]
    private AudioSource audioSource;

    private Vector2 _savedPosition;
    private bool _courantineHasStarted = false;

    private Dialog _dialogFirst;
    private Dialog _dialogSecond;
    public GameObject npcFirst;
    public GameObject npcSecond;


    protected override void Start()
    {
        base.Start();
        _dialogFirst = npcFirst.GetComponent<NPC>().dialog;
        _dialogSecond = npcSecond.GetComponent<NPC>().dialog;
    }

    public override void EventTrigger()
    {
        pointer.SetPointer(PointerType.FButton);
        base.EventTrigger();
    }

    public override void EventExit()
    {
        pointer.SetPointer(PointerType.TaskArrow);
        base.EventExit();
    }

    public override void Interact()
    {
        npcFirst.GetComponentInChildren<GameObject>().SetActive(true);
        npcSecond.GetComponentInChildren<GameObject>().SetActive(true);
        audioSource.PlayOneShot(interactSound);
        playerAnimations.TriggerInteraction(InteractionType.Drink);
        pointer.SetState(false);

        if (!_courantineHasStarted)
            StartCoroutine(WorkingTime());

        //Move Player to the position
        _savedPosition = player.gameObject.transform.position;
        player.gameObject.transform.position = gameObject.transform.position;
    }

    private IEnumerator WorkingTime()
    {
        _courantineHasStarted = true;
        audioSource.PlayOneShot(actionSound);
        
        GameObject fDialogWindow = InterfaceOnScene.Instance.CreateDialogWindow(npcFirst.transform, _dialogFirst.sentences[0]);
        yield return new WaitForSeconds(talkTime);
        Destroy(fDialogWindow);
        
        yield return new WaitForSeconds(1);

        GameObject sDialogWindow =
            InterfaceOnScene.Instance.CreateDialogWindow(npcSecond.transform, _dialogSecond.sentences[0]);
        yield return new WaitForSeconds(talkTime);
        Destroy(sDialogWindow);
        
        yield return new WaitForSeconds(1);
        

        player.gameObject.transform.position = _savedPosition;
        movement.EnableMovement();
        playerAnimations.StopDrinking(); 
        _courantineHasStarted = false;

        eventManager.SwitchEvent();
        pointer.SetState(true);
        base.Interact(); // Moves camera
    }
}
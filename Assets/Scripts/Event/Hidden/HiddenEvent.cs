using UnityEngine;

public class HiddenEvent : MonoBehaviour, IInteraction
{
    protected BoxCollider2D eventTrigger;
    protected bool isDone = false;
    protected EventManager eventManager;
    
    protected PlayerBase player;
    protected Movement movement;
    protected PlayerAnimations playerAnimations;

    [SerializeField] protected float eventRange = 2f;

    
    protected virtual void Start()
    {
        eventTrigger = GetComponent<BoxCollider2D>();
        eventTrigger.size = new Vector2(eventRange, eventRange);
        eventTrigger.isTrigger = true;
        
        eventManager = OfficeTimeManager.Instance.GetComponent<EventManager>();

        player = PlayerBase.Instance;
        movement = player.GetComponent<Movement>();
        playerAnimations = player.GetComponent<PlayerAnimations>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            EventTrigger();
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            EventExit();
    }

    public virtual void EventTrigger()
    {
        player.SetInteraction(this);
    }

    public virtual void EventExit()
    {
        player.SetInteraction(null);
    }
    
    public virtual void Interact()
    {
        
    }
    
}
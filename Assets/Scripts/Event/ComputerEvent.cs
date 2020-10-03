using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerEvent : Event,Interaction
{
    public float WorkTime = 60f;
    private SpriteRenderer _spriteRenderer;
    private PlayerBase _player;
    private Movement _movement;
    private IEnumerator coroutine;
    private Vector2 _savedPosition;
    private bool _courantineHasStarted = false;

    public override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        _player = PlayerBase.Instance;
        _movement = _player.GetComponent<Movement>();
    }

    public override void EventTrigger()
    {
        _spriteRenderer.enabled = true;
        _player.SetInteraction(this);
    }

    public override void EventExit()
    {
        _spriteRenderer.enabled = false;
        _player.SetInteraction(null);

    }

    public void Interact()
    {
        Debug.Log("Works hard on PC");

        _spriteRenderer.enabled = false;

        Time.timeScale = 2;

        coroutine = WorkingTime(WorkTime);
        if(!_courantineHasStarted)
            StartCoroutine(coroutine);

        //Move Player to the position
        _savedPosition = _player.gameObject.transform.position;
        _player.gameObject.transform.position = gameObject.transform.position;

    }

    private IEnumerator WorkingTime(float waitTime)
    {
        _courantineHasStarted = true;

        _movement.DisableMovement();
        yield return new WaitForSeconds(waitTime);

        Time.timeScale = 1;
        _player.gameObject.transform.position = _savedPosition;
        _movement.StartMoving();

        _courantineHasStarted = false;
        Debug.Log("Need some coffe");
    }
}

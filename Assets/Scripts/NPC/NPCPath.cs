using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NPCRenderer))]
[RequireComponent(typeof(LayerRenderer))]

public class NPCPath : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] private Transform travelPointsParent;
    public Transform[] _travelPoints;

    [SerializeField]
    private float standTime = 15f;

    private int _curentIndex = 0;
    private bool _reverseWay = false;
    private bool _moving = true;
    private bool _courantineHasStarted = false;
    private Animator _animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(_travelPoints[_curentIndex].position,transform.position) < 0.1f)
        {
            if (_curentIndex == 0)
            {
                _reverseWay = false;
                if(!_courantineHasStarted)
                    StartCoroutine(StandTime());
            }

            if (_curentIndex == _travelPoints.Length - 1)
            {
                _reverseWay = true;
                if (!_courantineHasStarted)
                    StartCoroutine(StandTime());
            }

            if (!_reverseWay)
                _curentIndex++;
            else
            {
                _curentIndex--;
            }
        }

        Vector3 dir = (_travelPoints[_curentIndex].position - transform.position).normalized;

        _animator.SetFloat("Horizontal", dir.x);
        _animator.SetFloat("Vertical", dir.y);

        if (_moving)
        {
            transform.position += dir * speed * Time.deltaTime;
            _animator.SetFloat("Speed", 1f);
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
        
    }

    public void SetMovement(bool state)
    {
        _moving = state;
    }
    
    private IEnumerator StandTime()
    {
        _courantineHasStarted = true;
        _moving = false;

        yield return new WaitForSeconds(standTime);

        _moving = true;
        _courantineHasStarted = false;
    }
    
}

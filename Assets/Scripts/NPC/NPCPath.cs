﻿using System.Collections;
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
    private Transform[] _travelPoints;

    [SerializeField]
    private float standTime = 15f;

    private int _curentIndex = 0;
    private bool _reverseWay = false;
    private bool _Moving = true;
    private bool _courantineHasStarted = false;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        _travelPoints = travelPointsParent.GetComponentsInChildren<Transform>();
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

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);

        if (_Moving)
        {
            transform.position += dir * speed * Time.deltaTime;
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
        
    }

    private IEnumerator StandTime()
    {
        _courantineHasStarted = true;
        _Moving = false;

        yield return new WaitForSeconds(standTime);

        _Moving = true;
        _courantineHasStarted = false;
    }
}

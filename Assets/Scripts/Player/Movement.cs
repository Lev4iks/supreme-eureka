﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    private Vector2 _movementDirection;

    [Range(1.0f, 10.0f)]
    public float movementSpeed;

    private Vector2 _lastDir;
    private Rigidbody2D _rb2D;
    private Animator _movementAnimator;
    private bool _isMoving = true;

    
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _movementAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_isMoving)
            ProcessInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void ProcessInputs()
    {
        _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_movementDirection.x != 0 || _movementDirection.y != 0)
        {
            _lastDir.x = _movementDirection.x;
            _lastDir.y = _movementDirection.y;
        }

        ProccesAnimation();
    }

    public void MovePlayer()
    {
        _rb2D.MovePosition(_rb2D.position + _movementDirection * 
                          movementSpeed * Time.fixedDeltaTime);
    }

    public void ProccesAnimation()
    {
        _movementAnimator.SetFloat("Horizontal", _lastDir.x);
        _movementAnimator.SetFloat("Vertical", _lastDir.y);
    }

    public void DisableMovement()
    {
        _isMoving = false;
    }

    public void StartMoving()
    {
        _isMoving = true;
    }
    
}

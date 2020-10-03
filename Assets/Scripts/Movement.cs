using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 _movementDirection;
    [Range(1.0f, 10.0f)]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Animator movementAnimator;
    [SerializeField] private Boolean TopDown = false;

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void ProcessInputs()
    {
        if (!TopDown)
        {
            _movementDirection.x = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump !");
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
            }
        }
        else if (TopDown)
        {
            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    public void MovePlayer()
    {
        rb2D.MovePosition(rb2D.position + _movementDirection * 
                          movementSpeed * Time.fixedDeltaTime);
    }

}

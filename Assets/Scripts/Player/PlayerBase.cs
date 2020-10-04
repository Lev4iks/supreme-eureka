using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    
    #region Singleton

    public static PlayerBase Instance;
    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
    #endregion

    private IInteraction _interaction;
    private Movement _playerMovement;


    private void Start()
    {
        _playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F)) return;
        if (_interaction == null) return;

        _playerMovement.DisableMovement();
        _interaction.Interact();
        _interaction = null;
    }

    public void SetInteraction(IInteraction interaction)
    {
        _interaction = interaction;
    }
    
}

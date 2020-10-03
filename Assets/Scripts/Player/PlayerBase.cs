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

    private Interaction _interaction;

    private void Update()
    {
        //Sania prosty, ne bei!

        if (_interaction!= null)
        {
            if (Input.GetKeyDown(KeyCode.F))
                _interaction.Interact();
        }
    }

    public void SetInteraction(Interaction interaction)
    {
        _interaction = interaction;
    }
    
}

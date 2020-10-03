using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceOnScene : MonoBehaviour
{
    #region Singleton

    public static InterfaceOnScene Instance;
    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
        _dayNameLabel = GetComponentInChildren<TextMeshProUGUI>();
    }
    #endregion

    
    private TextMeshProUGUI _dayNameLabel;
    public float dayLabelTimeDisplay = 2f;
    

    public void SetDayName(string name)
    {
        _dayNameLabel.text = name;
    }

    public void TriggerDayLabel()
    {
        StartCoroutine(LabelTime());
    }

    private IEnumerator LabelTime()
    {
        _dayNameLabel.enabled = true;
        yield return new WaitForSeconds(dayLabelTimeDisplay);
        _dayNameLabel.enabled = false;
    }
    
}

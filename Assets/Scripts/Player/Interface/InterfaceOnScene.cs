using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceOnScene : MonoBehaviour
{
    public float DayLabelTimeDisplay = 2f;

    private TextMeshProUGUI DayNameLabel;

    #region Singleton

    public static InterfaceOnScene Instance;
    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
        DayNameLabel = GetComponentInChildren<TextMeshProUGUI>();
    }
    #endregion

    

    public void SetDayName(string name)
    {
        DayNameLabel.text = name;
    }

    public void TriggerDayLabel()
    {
        StartCoroutine(LabelTime());
    }

    private IEnumerator LabelTime()
    {
        DayNameLabel.enabled = true;
        yield return new WaitForSeconds(DayLabelTimeDisplay);
        DayNameLabel.enabled = false;
    }
}

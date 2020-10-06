using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

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


    private GameObject _dialogWindow;
    private GameObject _bossDialogWindow;
    private GameObject _selfDialogWindow;
    private RectTransform _canvasRect;
    private TextMeshProUGUI _dayNameLabel;

    public bool isDay;
    public float dayLabelTimeDisplay = 2f;
    public RectTransform CanvasRect => _canvasRect;

    public Light2D mainLight;
    
    public TMP_Text hours;
    public TMP_Text minutes;


    private void Start()
    {
        _dialogWindow = Resources.Load<GameObject>("DialogWindow");
        _bossDialogWindow = Resources.Load<GameObject>("BossDialogWindow");
        _selfDialogWindow = Resources.Load<GameObject>("SelfDialogWindow");
        _canvasRect = GetComponent<Canvas>().GetComponent<RectTransform>();

        if (isDay)
        {
            hours.SetText("10");
            minutes.SetText("58");
        }

    }

    public void SetTime(float time)
    {
        if (isDay)
        {        
            var h = Mathf.RoundToInt(time) / 60;
            var m = Mathf.RoundToInt(time) % 60;

            if (Mathf.Abs(18 - h) > 16)
                mainLight.intensity = 0.8f;
            
            hours.SetText(Mathf.Abs(18 - h).ToString());
            if (m == 0)
                minutes.SetText("59");
            else if (Mathf.Abs(60 - m) < 10)
                minutes.SetText("0" + Mathf.Abs(60 - m).ToString());
            else
                minutes.SetText(Mathf.Abs(60 - m).ToString());
        }
    }

    public void SetDayName(string name)
    {
        if (_dayNameLabel)
            _dayNameLabel.text = name;
    }

    public void TriggerDayLabel()
    {
        StartCoroutine(LabelTime());
    }

    private IEnumerator LabelTime()
    {
        if (_dayNameLabel)
        {
            _dayNameLabel.enabled = true;
            yield return new WaitForSeconds(dayLabelTimeDisplay);
            _dayNameLabel.enabled = false;
        }
    }

    public GameObject CreateDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(_dialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);
        
        return dWindow;
    }
    
    public GameObject CreateBossDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(_bossDialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);

        return dWindow;
    }
    
    public GameObject CreateSelfDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(_selfDialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);

        return dWindow;
    }

}

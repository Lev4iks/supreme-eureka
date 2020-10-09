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

    [SerializeField]
    private GameObject dialogWindow;
    [SerializeField]
    private GameObject bossDialogWindow;
    [SerializeField]
    private GameObject selfDialogWindow;
    private RectTransform _canvasRect;
    private TextMeshProUGUI _dayNameLabel;

    public bool isDay;
    public float dayLabelTimeDisplay = 2f;
    public RectTransform CanvasRect => _canvasRect;

    public Light2D mainLight;
    public float nightIntensity = 0.7f;
    [Space]
    public TMP_Text hours;
    public TMP_Text minutes;


    private void Start()
    {
        _canvasRect = GetComponent<Canvas>().GetComponent<RectTransform>();

        if (isDay)
        {
            hours.SetText("10");
            minutes.SetText("58");
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void SetTime(float time)
    {
        if (isDay)
        {        
            var h = Mathf.RoundToInt(time) / 60;
            var m = Mathf.RoundToInt(time) % 60;

            if (Mathf.Abs(18 - h) > 16)
                mainLight.intensity = nightIntensity;
            
            hours.SetText(Mathf.Abs(18 - h).ToString());
            if (m == 0)
                minutes.SetText("00");
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
        GameObject dWindow = Instantiate(dialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);
        
        return dWindow;
    }
    
    public GameObject CreateBossDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(bossDialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);

        return dWindow;
    }
    
    public GameObject CreateSelfDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(selfDialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);

        return dWindow;
    }

}

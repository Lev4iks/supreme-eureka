using System;
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


    private GameObject _dialogWindow;
    private RectTransform _canvasRect;
    private TextMeshProUGUI _dayNameLabel;

    public float dayLabelTimeDisplay = 2f;
    public RectTransform CanvasRect => _canvasRect;
    public TMP_Text hours;
    public TMP_Text minutes;


    private void Start()
    {
        _dialogWindow = Resources.Load<GameObject>("DialogWindow");
        _canvasRect = GetComponent<Canvas>().GetComponent<RectTransform>();
    }

    private void Update()
    {
        
    }

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

    public GameObject CreateDialogWindow(Transform character, string dialog)
    {
        GameObject dWindow = Instantiate(_dialogWindow, character.position, Quaternion.identity, transform);
        dWindow.GetComponent<DialogWindow>().SetOptions(character, dialog);

        return dWindow;
    }

}

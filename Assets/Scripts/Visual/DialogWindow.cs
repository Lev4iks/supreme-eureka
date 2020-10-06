using System;
using TMPro;
using UnityEngine;


public enum DialogWindowType
{
    Self = 0,
    Boss = 1,
    Other = 2
}


public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text dialog;

    private Transform _character;
    private Camera _playerCamera;
    private RectTransform _selfRect;
    private RectTransform _canvasRect;
    public DialogWindowType dialogWindowType;
    

    private void Start()
    {
        _playerCamera = PlayerCamera.Instance.GetComponent<Camera>();
        _selfRect = GetComponent<RectTransform>();
    }

    public void SetOptions(Transform character, string dialog)
    {
        this.dialog.SetText(dialog);
        _character = character;
        _canvasRect = InterfaceOnScene.Instance.CanvasRect;
    }

    private void Update()
    {
        switch (dialogWindowType)
        {
            case DialogWindowType.Boss:
                _selfRect.anchoredPosition = BossPointsToScreenTranslate(_character, _canvasRect);
                break;
            case DialogWindowType.Self:
                _selfRect.anchoredPosition = SelfPointsToScreenTranslate(_character, _canvasRect);
                break;
            case DialogWindowType.Other:
                _selfRect.anchoredPosition = OtherPointsToScreenTranslate(_character, _canvasRect);
                break;
        }
    }
    
    private Vector2 OtherPointsToScreenTranslate(Transform world, RectTransform screen)
    {
        var sizeDelta = screen.sizeDelta;
        var newPosition = world.transform.position + Vector3.up * 2.7f + Vector3.right * 2.1f;
        
        
        Vector2 viewportPosition = _playerCamera.WorldToViewportPoint(newPosition);
        Vector2 worldScreenPosition = new Vector3(
            ((viewportPosition.x * sizeDelta.x) - (sizeDelta.x * 0.5f)),
            ((viewportPosition.y * sizeDelta.y) - (sizeDelta.y * 0.5f)));

        return worldScreenPosition;
    }
    
    private Vector2 BossPointsToScreenTranslate(Transform world, RectTransform screen)
    {
        var sizeDelta = screen.sizeDelta;
        var newPosition = world.transform.position + Vector3.down * 3f + Vector3.right * 4f;
        
        
        Vector2 viewportPosition = _playerCamera.WorldToViewportPoint(newPosition);
        Vector2 worldScreenPosition = new Vector3(
            ((viewportPosition.x * sizeDelta.x) - (sizeDelta.x * 0.5f)),
            ((viewportPosition.y * sizeDelta.y) - (sizeDelta.y * 0.5f)));

        return worldScreenPosition;
    }
    
    private Vector2 SelfPointsToScreenTranslate(Transform world, RectTransform screen)
    {
        var sizeDelta = screen.sizeDelta;
        var newPosition = world.transform.position + Vector3.up * 3f + Vector3.right * 4f;
        
        
        Vector2 viewportPosition = _playerCamera.WorldToViewportPoint(newPosition);
        Vector2 worldScreenPosition = new Vector3(
            ((viewportPosition.x * sizeDelta.x) - (sizeDelta.x * 0.5f)),
            ((viewportPosition.y * sizeDelta.y) - (sizeDelta.y * 0.5f)));

        return worldScreenPosition;
    }
    
}
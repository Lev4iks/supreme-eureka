using System;
using TMPro;
using UnityEngine;


public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialog;

    private Transform _character;
    private Camera _playerCamera;
    private RectTransform _selfRect;
    private RectTransform _canvasRect;


    private void Start()
    {
        _playerCamera = PlayerCamera.Instance.GetComponent<Camera>();
        _selfRect = GetComponent<RectTransform>();
    }

    public void SetOptions(Transform character, string characterName, string dialog)
    {
        this.characterName.SetText(characterName);
        this.dialog.SetText(dialog);
        _character = character;
        _canvasRect = InterfaceOnScene.Instance.CanvasRect;
    }

    private void Update()
    {
        _selfRect.anchoredPosition = WorldPointsToScreenTranslate(_character, _canvasRect);
    }
    
    private Vector2 WorldPointsToScreenTranslate(Transform world, RectTransform screen)
    {
        var sizeDelta = screen.sizeDelta;
        
        Vector2 viewportPosition = _playerCamera.WorldToViewportPoint(world.transform.position);
        Vector2 worldScreenPosition = new Vector3(
            ((viewportPosition.x * sizeDelta.x) - (sizeDelta.x * 0.5f)),
            ((viewportPosition.y * sizeDelta.y) - (sizeDelta.y * 0.5f)));

        return worldScreenPosition;
    }
    
}
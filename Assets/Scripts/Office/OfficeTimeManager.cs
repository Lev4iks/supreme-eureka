using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScenesManager))]
[RequireComponent(typeof(EventManager))]

public class OfficeTimeManager : MonoBehaviour
{
    public static OfficeTimeManager Instance;
    public float TimeForDay = 480f;
    public float CrossFadeTime = 2;
    public Scenes NextScene;
    public string SceneName;

    private SceneCrossfade _sceneCrossfade;
    private ScenesManager _scenesManager;
    private bool _timeStopped = false;

    #region Singleton
    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _sceneCrossfade = InterfaceOnScene.Instance.GetComponentInChildren<SceneCrossfade>();
        _scenesManager = GetComponent<ScenesManager>();
    }

    void Update()
    {
        if (TimeForDay <= 0)
        {
            Time.timeScale = 1;
            StartCoroutine(CrossFadeDuration());
        }
        else if (!_timeStopped)
        {
            TimeForDay -= Time.deltaTime * 2;
        }
    }

    private void LateUpdate()
    {
        if (!_timeStopped && InterfaceOnScene.Instance)
            InterfaceOnScene.Instance.SetTime(TimeForDay);
    }

    private IEnumerator CrossFadeDuration()
    {
        _sceneCrossfade.TriggerCrossfade(true);
        yield return new WaitForSeconds(CrossFadeTime);
        _scenesManager.LoadScene(NextScene);
    }

    public void StopTime()
    {
        _timeStopped = true;
    }

    public void ResumeTime()
    {
        _timeStopped = false;
    }
    
}

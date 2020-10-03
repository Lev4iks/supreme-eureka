using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScenesManager))]

public class OfficeTimeManager : MonoBehaviour
{
    public static OfficeTimeManager Instance;
    public float TimeForDay = 300f;
    public float CrossFadeTime = 2;
    public ScenesManager.Scenes NextScene;

    private SceneCrossfade _sceneCrossfade;
    private ScenesManager _scenesManager;

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
        if(TimeForDay <= 0)
        {
            StartCoroutine(CrossFadeDuration());
        }
        else
        {
            TimeForDay -= Time.deltaTime;
        }
    }

    private IEnumerator CrossFadeDuration()
    {
        _sceneCrossfade.TriggerCrossfade(true);
        yield return new WaitForSeconds(CrossFadeTime);
        _scenesManager.LoadScene(NextScene);
    }
}

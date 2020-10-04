using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ScenesManager:MonoBehaviour
{

    public enum Scenes
    {
        Day1 = 0,
        Day2,
        Day3,
        Day4,
        Day5,
        NightChat,
    }

    public void LoadScene(Scenes scenes, Vector3 position = new Vector3())
    {
        SceneManager.LoadScene(scenes.ToString());
 
    }

    public void LoadScene(String scenes, Vector3 position = new Vector3())
    {
        SceneManager.LoadScene(scenes);
    }

}
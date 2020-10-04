using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public enum Scenes
{
    day1 = 0,
    day2 = 1,
    day3 = 2,
    day4 = 3,
    day5 = 4,
    NightChat1 = 5,
    NightChat2 = 5,
    NightChat3 = 5,
    NightChat4 = 5,
    NightChat5 = 5,
    EndScene,
}

public class ScenesManager: MonoBehaviour
{
    
    public void LoadScene(Scenes scenes, Vector3 position = new Vector3())
    {
        SceneManager.LoadScene(scenes.ToString());
 
    }

    public void LoadScene(String scenes, Vector3 position = new Vector3())
    {
        SceneManager.LoadScene(scenes);
    }

}
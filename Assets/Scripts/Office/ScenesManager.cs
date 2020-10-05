using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public enum Scenes
{
    Day1 = 0,
    Day2 = 1,
    Day3 = 2,
    Day4 = 3,
    Day5 = 4,
    NightChat1 = 5,
    NightChat2 = 6,
    NightChat3 = 7,
    NightChat4 = 8,
    BadEndScene = 9,
    GoodEndScene = 10,
    StartScene = 11,
    End
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
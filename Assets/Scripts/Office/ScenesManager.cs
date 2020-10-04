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
    NightChat = 5,
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip step;
    [SerializeField]
    private AudioSource audioSource;

    public void PlayStep()
    {
        audioSource.PlayOneShot(step);
    }
}

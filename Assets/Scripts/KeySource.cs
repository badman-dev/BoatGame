using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KeySource : MonoBehaviour
{
    public int keyID = 0;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayUnlockSound()
    {
        audio.Play();
    }
}

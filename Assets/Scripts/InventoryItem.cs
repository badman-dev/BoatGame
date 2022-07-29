using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InventoryItem : MonoBehaviour
{
    public PlayerInventory inventory;

    public bool throwable;

    public AudioClip pickupSound;
    public AudioClip putdownSound;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Pickup()
    {
        audio.clip = pickupSound;
        audio.Play();
    }

    public void Putdown()
    {
        audio.clip = putdownSound;
        audio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InventoryItem : MonoBehaviour
{
    public PlayerInventory inventory;

    public AudioClip pickupSound;

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
}

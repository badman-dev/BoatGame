using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGameplay : MonoBehaviour
{
    Waves waveScript;
    BoxCollider col;
    AudioSource audioSrc;

    void Start()
    {
        waveScript = GetComponent<Waves>();
        col = GetComponent<BoxCollider>();
        audioSrc = GetComponentInChildren<AudioSource>();

        float waveWidth = waveScript.dimension;
        col.center = new Vector3(waveWidth / 2, 0, waveWidth / 2);
        col.size = new Vector3(waveWidth, .25f, waveWidth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<InventoryItem>())
        {
            ItemSplash(other.gameObject);
        }
    }

    public void ItemSplash(GameObject other)
    {
        audioSrc.transform.position = other.transform.position;
        audioSrc.Play();

        MonsterController[] monsters = FindObjectsOfType<MonsterController>();

        Transform chasePoint = new GameObject("ChasePoint").transform;
        chasePoint.gameObject.tag = "ChasePoint";
        chasePoint.position = other.transform.position;

        foreach (MonsterController monster in monsters)
        {
            if (Vector3.Distance(chasePoint.position, monster.transform.position) <= monster.chaseRadius * 4)
            {
                monster.StartChase(chasePoint.transform);
            }
        }
    }
}

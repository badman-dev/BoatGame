using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    public UnityEvent onEnter;

    public Collider target;

    BoxCollider col;

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == target)
            onEnter.Invoke();
    }
}

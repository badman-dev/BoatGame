using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDestination : MonoBehaviour
{
    public int lockID;
    public UnityEvent onUnlock;

    public bool AttemptUnlock(int inputID)
    {
        if (lockID == inputID)
        {
            onUnlock.Invoke();
            return true;
        }

        return false;
    }
}

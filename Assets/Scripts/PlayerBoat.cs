using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoat : MonoBehaviour
{
    public float rotateSpeed = 0;
    public float rowSpeed = 0;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0)
        {
            transform.Rotate(0, x * rotateSpeed, 0);
        }

        if (z != 0)
        {
            transform.Translate(0, 0, z * rowSpeed);
        }
    }
}

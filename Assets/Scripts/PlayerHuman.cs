using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;

    float mouseSensitivity = 600f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotation.x += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
}

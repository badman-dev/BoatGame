using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;

    float mouseSensitivity = 600f;

    float maxInteractDistance = 10f;

    public PlayerInventory inventory;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotation.x += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxInteractDistance))
            {
                if (hit.transform.gameObject.GetComponent<InventoryItem>())
                    inventory.InventoryAdd(hit.transform.gameObject);
            }
        }
    }

    void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
